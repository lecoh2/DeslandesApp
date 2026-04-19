using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Evento;
using DeslandesApp.Domain.Models.Dtos.Requests.Kaban;
using DeslandesApp.Domain.Models.Dtos.Responses.Evento;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Tarefa;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Domain.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class EventoService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : IEventoService
    {
        public async Task<CriarEventoResponse> AdicionarAsync(CriarEventoRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                // DTO -> Entidade
                var evento = mapper.Map<Evento>(request);

                var agora = DateTime.Now;
                var hoje = DateOnly.FromDateTime(agora);
                var horaAtual = TimeOnly.FromDateTime(agora);
                evento.UsuarioCriacaoId = ObterUsuarioId();
                // =========================
                // 🧠 STATUS KANBAN
                // =========================
                if (request.StatusKaban.HasValue)
                {
                    evento.StatusGeralKanban = request.StatusKaban.Value;
                }

                // 🔥 STATUS AUTOMÁTICO (INTELIGENTE)
                if (evento.DataFinal.HasValue && evento.DataFinal.Value < hoje)
                {
                    evento.StatusGeralKanban = StatusGeralKanban.Concluido;
                }
                else if (evento.DataInicial == hoje &&
                         evento.HoraInicial <= horaAtual &&
                         (evento.HoraFinal == null || evento.HoraFinal >= horaAtual))
                {
                    evento.StatusGeralKanban = StatusGeralKanban.Em_Andamento;
                }

                // =========================
                // 🧹 NORMALIZAÇÃO
                // =========================
                evento.Titulo = evento.Titulo.Trim();
                evento.Endereco = evento.Endereco?.Trim();
                evento.Observacao = evento.Observacao?.Trim();
                evento.DataCadastro = DateTime.Now;
                // =========================
                // 🕒 DIA INTEIRO
                // =========================
                if (evento.DiaInteiro)
                {
                    evento.HoraInicial = TimeOnly.MinValue;
                    evento.HoraFinal = TimeOnly.MaxValue;
                }

                // =========================
                // 🔁 RECORRÊNCIA
                // =========================
                if (evento.IntervaloRecorrencia < 1)
                    throw new InvalidOperationException("Intervalo da recorrência deve ser maior ou igual a 1.");

                if (evento.TipoRecorrencia != TipoRecorrencia.Nenhuma)
                {
                    if (evento.DataFimRecorrencia.HasValue && evento.QuantidadeOcorrencias.HasValue)
                        throw new InvalidOperationException("Informe apenas DataFimRecorrencia ou QuantidadeOcorrencias.");

                    if (!evento.DataFimRecorrencia.HasValue && !evento.QuantidadeOcorrencias.HasValue)
                        throw new InvalidOperationException("Recorrência precisa de um critério de término.");

                    if (evento.TipoRecorrencia == TipoRecorrencia.Semanal &&
                        (evento.DiasSemana == null || !evento.DiasSemana.Any()))
                        throw new InvalidOperationException("Informe ao menos um dia da semana para recorrência semanal.");
                }
                else
                {
                    evento.IntervaloRecorrencia = 1;
                    evento.DiasSemana = new List<DayOfWeek>();
                    evento.DataFimRecorrencia = null;
                    evento.QuantidadeOcorrencias = null;
                }
                // 🔗 VALIDAÇÃO DE VÍNCULOS
                int count = 0;
                if (request.ProcessoId.HasValue) count++;
                if (request.CasoId.HasValue) count++;
                if (request.AtendimentoId.HasValue) count++;

                if (count > 1)
                    throw new InvalidOperationException("A tarefa não pode ter mais de um vínculo.");

                // VÍNCULOS
                if (request.ProcessoId.HasValue)
                {
                    var processo = await unitOfWork.ProcessoRepository.GetByIdAsync(request.ProcessoId.Value);
                    if (processo == null)
                        throw new InvalidOperationException("Processo não encontrado.");

                    evento.ProcessoId = processo.Id;
                    evento.TipoVinculo = TipoVinculo.Processo;
                }
                else if (request.CasoId.HasValue)
                {
                    var caso = await unitOfWork.CasoRepository.GetByIdAsync(request.CasoId.Value);
                    if (caso == null)
                        throw new InvalidOperationException("Caso não encontrado.");

                    evento.CasoId = caso.Id;
                    evento.TipoVinculo = TipoVinculo.Caso;
                }
                else if (request.AtendimentoId.HasValue)
                {
                    var atendimento = await unitOfWork.AtendimentoRepository.GetByIdAsync(request.AtendimentoId.Value);
                    if (atendimento == null)
                        throw new InvalidOperationException("Atendimento não encontrado.");

                    evento.AtendimentoId = atendimento.Id;
                    evento.TipoVinculo = TipoVinculo.Atendimento;
                }
                else
                {
                    evento.TipoVinculo = null;
                }
                // =========================
                // ✅ VALIDAÇÃO
                // =========================
                var validator = new EventoValidator();
                var result = validator.Validate(evento);

                if (!result.IsValid)
                    throw new ValidationException(result.Errors);

                // =========================
                // 💾 SALVAR EVENTO
                // =========================
                await unitOfWork.EventoRepository.AddAsync(evento);

                // =========================
                // 👥 RESPONSÁVEIS (N:N)
                // =========================
                if (request.GrupoEventoResponsavel != null && request.GrupoEventoResponsavel.Any())
                {
                    foreach (var item in request.GrupoEventoResponsavel)
                    {
                        var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(item.UsuarioId);

                        if (usuario == null)
                            throw new InvalidOperationException($"Usuário {item.UsuarioId} não encontrado.");

                        var grupo = new GrupoEventoResponsavel
                        {
                            EventoId = evento.Id,
                            UsuarioId = item.UsuarioId
                        };

                        await unitOfWork.GrupoEventoResponsavelRepository.AddAsync(grupo);
                    }
                } // Etiquetas
                if (request.GrupoEventoEtiquestas != null && request.GrupoEventoEtiquestas.Any())
                {
                    foreach (var grupoEtiqueta in request.GrupoEventoEtiquestas)
                    {
                        var etiqueta = await unitOfWork.EtiquetaRepository
                            .GetByIdAsync(grupoEtiqueta.EtiquetaId);

                        if (etiqueta == null)
                            throw new InvalidOperationException("Etiqueta não encontrada.");

                        await unitOfWork.GrupoEventoEtiquetasRepository.AddAsync(new GrupoEventoEtiquetas
                        {
                            EventoId = evento.Id,
                            EtiquetaId = grupoEtiqueta.EtiquetaId
                        });
                    }
                }

                await unitOfWork.CommitAsync();

                return mapper.Map<CriarEventoResponse>(evento);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task<PageResult<CriarEventoResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public async Task<PageResult<EventoPaginacaoResponse>> ConsultarEventoPaginacaoAsync(
     int pageNumber,
     int pageSize,
     string? searchTerm = null)
        {
            var paged = await unitOfWork.EventoRepository
                .GetEventoPaginacaoAsync(pageNumber, pageSize, searchTerm);

            if (paged == null || !paged.Items.Any())
            {
                return new PageResult<EventoPaginacaoResponse>
                {
                    Items = new List<EventoPaginacaoResponse>(),
                    TotalCount = 0,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }

            return paged;
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<CriarEventoResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CriarEventoResponse> ModificarAsync(Guid id, UpdateEventoRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var evento = await unitOfWork.EventoRepository.GetByIdAsync(id);

                if (evento == null)
                    throw new ApplicationException("Evento não encontrado.");

                var usuarioId = ObterUsuarioId();

                // =========================
                // ANTES (COM RELACIONAMENTOS)
                // =========================
                var eventoAntes = await unitOfWork.EventoRepository
                    .ConsultarEventoComRelacionamentosAsync(id);

                if (eventoAntes == null)
                    throw new ApplicationException("Evento para histórico não encontrado.");

                var dadosAntes = new
                {
                    eventoAntes.Titulo,
                    eventoAntes.DataInicial,
                    eventoAntes.HoraInicial,
                    eventoAntes.DataFinal,
                    eventoAntes.HoraFinal,
                    eventoAntes.DiaInteiro,
                    eventoAntes.Endereco,
                    eventoAntes.Observacao,
                    eventoAntes.Modalidade,
                    eventoAntes.StatusGeralKanban,

                    Responsaveis = eventoAntes.GrupoEventoResponsavel?
                        .Select(r => r.Usuario?.NomeUsuario)
                        .Where(n => n != null)
                        .ToList()
                };

                //  =========================
                // ATUALIZAÇÃO
                // =========================
                mapper.Map(request, evento);

                var agora = DateTime.Now;
                var hoje = DateOnly.FromDateTime(agora);
                var horaAtual = TimeOnly.FromDateTime(agora);

                //  STATUS
                evento.StatusGeralKanban = request.StatusKaban ?? evento.StatusGeralKanban;

                if (evento.DataFinal.HasValue && evento.DataFinal.Value < hoje)
                {
                    evento.StatusGeralKanban = StatusGeralKanban.Concluido;
                }
                else if (evento.DataInicial == hoje &&
                         evento.HoraInicial <= horaAtual &&
                         (evento.HoraFinal == null || evento.HoraFinal >= horaAtual))
                {
                    evento.StatusGeralKanban = StatusGeralKanban.Em_Andamento;
                }

                //  NORMALIZAÇÃO
                evento.Titulo = evento.Titulo.Trim();
                evento.Endereco = evento.Endereco?.Trim();
                evento.Observacao = evento.Observacao?.Trim();

                //  DIA INTEIRO
                if (evento.DiaInteiro)
                {
                    evento.HoraInicial = TimeOnly.MinValue;
                    evento.HoraFinal = TimeOnly.MaxValue;
                }

                //  RECORRÊNCIA
                if (evento.IntervaloRecorrencia < 1)
                    throw new InvalidOperationException("Intervalo da recorrência deve ser maior ou igual a 1.");

                if (evento.TipoRecorrencia != TipoRecorrencia.Nenhuma)
                {
                    if (evento.DataFimRecorrencia.HasValue && evento.QuantidadeOcorrencias.HasValue)
                        throw new InvalidOperationException("Informe apenas DataFimRecorrencia ou QuantidadeOcorrencias.");

                    if (!evento.DataFimRecorrencia.HasValue && !evento.QuantidadeOcorrencias.HasValue)
                        throw new InvalidOperationException("Recorrência precisa de um critério de término.");

                    if (evento.TipoRecorrencia == TipoRecorrencia.Semanal &&
                        (evento.DiasSemana == null || !evento.DiasSemana.Any()))
                        throw new InvalidOperationException("Informe ao menos um dia da semana.");
                }
                else
                {
                    evento.IntervaloRecorrencia = 1;
                    evento.DiasSemana = new List<DayOfWeek>();
                    evento.DataFimRecorrencia = null;
                    evento.QuantidadeOcorrencias = null;
                }

                //  VALIDAÇÃO
                var validator = new EventoValidator();
                var result = validator.Validate(evento);

                if (!result.IsValid)
                    throw new ValidationException(result.Errors);

                await unitOfWork.EventoRepository.UpdateAsync(evento);

                //  =========================
                // RESPONSÁVEIS (SE FOR ATUALIZAR)
                // =========================
                /*
                await unitOfWork.GrupoEventoResponsavelRepository.DeleteByEventoIdAsync(id);

                if (request.GrupoEventoResponsavel != null && request.GrupoEventoResponsavel.Any())
                {
                    foreach (var item in request.GrupoEventoResponsavel)
                    {
                        var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(item.UsuarioId);

                        if (usuario == null)
                            throw new InvalidOperationException($"Usuário {item.UsuarioId} não encontrado.");

                        await unitOfWork.GrupoEventoResponsavelRepository.AddAsync(new GrupoEventoResponsavel
                        {
                            EventoId = evento.Id,
                            UsuarioId = item.UsuarioId
                        });
                    }
                }
                */

                //  =========================
                // DEPOIS
                // =========================
                var eventoDepois = await unitOfWork.EventoRepository
                    .ConsultarEventoComRelacionamentosAsync(id);

                if (eventoDepois == null)
                    throw new ApplicationException("Evento atualizado não encontrado.");

                var dadosDepois = new
                {
                    eventoDepois.Titulo,
                    eventoDepois.DataInicial,
                    eventoDepois.HoraInicial,
                    eventoDepois.DataFinal,
                    eventoDepois.HoraFinal,
                    eventoDepois.DiaInteiro,
                    eventoDepois.Endereco,
                    eventoDepois.Observacao,
                    eventoDepois.Modalidade,
                    eventoDepois.StatusGeralKanban,

                    Responsaveis = eventoDepois.GrupoEventoResponsavel?
                        .Select(r => r.Usuario?.NomeUsuario)
                        .Where(n => n != null)
                        .ToList()
                };

                // 🧾 =========================
                // HISTÓRICO
                // =========================
                var historico = new EventoHistorico
                {
                    EventoId = evento.Id,
                    UsuarioId = usuarioId,
                    DataAlteracao = DateTime.Now,
                    Observacao = request.Observacao ?? "",
                    DadosAntes = JsonConvert.SerializeObject(dadosAntes),
                    DadosDepois = JsonConvert.SerializeObject(dadosDepois)
                };

                await unitOfWork.EventoHistoricoRepository.AddAsync(historico);

                await unitOfWork.CommitAsync();

                return mapper.Map<CriarEventoResponse>(eventoDepois);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task<CriarEventoResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task MoverCardAsync(MoverKanbanCardRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                if (request.Tipo == "Tarefa")
                {
                    var evento = await unitOfWork.EventoRepository.GetByIdAsync(request.Id);

                    if (evento == null)
                        throw new Exception("Tarefa não encontrada");

                    evento.StatusGeralKanban = request.NovoStatus;
                    evento.DataAtualizacao = DateTime.Now;
                }
                else if (request.Tipo == "Evento")
                {
                    var evento = await unitOfWork.EventoRepository.GetByIdAsync(request.Id);

                    if (evento == null)
                        throw new Exception("Evento não encontrado");

                    evento.StatusGeralKanban = request.NovoStatus;
                }
                else
                {
                    throw new Exception("Tipo inválido");
                }

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task AtualizarStatusAutomatico()
        {
            var hoje = DateOnly.FromDateTime(DateTime.Now);

            // Busca todos os eventos
            var eventos = await unitOfWork.EventoRepository.GetAllAsync();

            // Filtra apenas os que não estão concluídos e já passaram da data final
            var eventosParaAtualizar = eventos
                .Where(e => e.StatusGeralKanban != StatusGeralKanban.Concluido &&
                            e.DataFinal.HasValue && e.DataFinal < hoje)
                .ToList();

            foreach (var evento in eventosParaAtualizar)
            {
                evento.StatusGeralKanban = StatusGeralKanban.Concluido;
            }

            if (eventosParaAtualizar.Any())
                await unitOfWork.CommitAsync();
        }
        private Guid? ObterUsuarioId()
        {
            var user = httpContextAccessor.HttpContext?.User;

            var userId = user?.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(userId))
                return null;

            return Guid.Parse(userId);
        }
    }
}
