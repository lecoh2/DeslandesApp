using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.ListaTarefas;
using DeslandesApp.Domain.Models.Dtos.Requests.Processo;
using DeslandesApp.Domain.Models.Dtos.Requests.Tarefa;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Tarefa;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Domain.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DeslandesApp.Domain.Models.Dtos.Requests.Kaban;
using DeslandesApp.Domain.Models.Dtos.Responses.ListaTarefas;

namespace DeslandesApp.Domain.Services
{
    public class TarefaService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor,
         IHistoricoGeralService historicoService) : ITarefaService
    {
        public async Task<CriarTarefaResponse> AdicionarAsync(CriarTarefaRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            // DTO -> Entidade
            var tarefa = mapper.Map<Tarefa>(request);

            // Normalização
            tarefa.Descricao = tarefa.Descricao?.Trim();
            tarefa.DataCadastro = DateTime.Now;
            tarefa.DataAtualizacao = DateTime.Now;
            tarefa.StatusGeralKanban = request.StatusGeralKanban;
            tarefa.UsuarioCriacaoId = ObterUsuarioId();

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

                tarefa.ProcessoId = processo.Id;
                tarefa.TipoVinculo = TipoVinculo.Processo;
            }
            else if (request.CasoId.HasValue)
            {
                var caso = await unitOfWork.CasoRepository.GetByIdAsync(request.CasoId.Value);
                if (caso == null)
                    throw new InvalidOperationException("Caso não encontrado.");

                tarefa.CasoId = caso.Id;
                tarefa.TipoVinculo = TipoVinculo.Caso;
            }
            else if (request.AtendimentoId.HasValue)
            {
                var atendimento = await unitOfWork.AtendimentoRepository.GetByIdAsync(request.AtendimentoId.Value);
                if (atendimento == null)
                    throw new InvalidOperationException("Atendimento não encontrado.");

                tarefa.AtendimentoId = atendimento.Id;
                tarefa.TipoVinculo = TipoVinculo.Atendimento;
            }
            else
            {
                tarefa.TipoVinculo = null;
            }

            // Validação Fluent
            var validator = new TarefaValidator();
            var result = validator.Validate(tarefa);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            // Responsável
            if (tarefa.UsuarioCriacaoId.HasValue)
            {
                var usuario = await unitOfWork.UsuarioRepository
                    .GetByIdAsync(tarefa.UsuarioCriacaoId.Value);

                if (usuario == null)
                    throw new InvalidOperationException("Responsável não encontrado.");
            }

            // Salva tarefa
            await unitOfWork.TarefaRepository.AddAsync(tarefa);

            // =========================
            // CHECKLIST
            // =========================
            if (request.ListasTarefa != null && request.ListasTarefa.Any())
            {
                var ultimaOrdem = await unitOfWork.ListaTarefaRepository
                    .ObterMaiorOrdemPorTarefaId(tarefa.Id) ?? 0;

                int incremento = 0;

                foreach (var item in request.ListasTarefa)
                {
                    var descricao = item.Descricao?.Trim();

                    if (string.IsNullOrWhiteSpace(descricao))
                        continue;

                    incremento += 10;

                    var lista = new ListaTarefa
                    {
                        TarefaId = tarefa.Id,
                        Descricao = descricao,
                        Ordem = ultimaOrdem + incremento,

                        // ✔ CORRETO conforme sua entidade
                        Concluida = false,
                        DataConclusao = null
                    };

                    await unitOfWork.ListaTarefaRepository.AddAsync(lista);
                }
            }
            // Etiquetas
            if (request.GrupoTarefasEtiquetas != null && request.GrupoTarefasEtiquetas.Any())
            {
                foreach (var grupoEtiqueta in request.GrupoTarefasEtiquetas)
                {
                    var etiqueta = await unitOfWork.EtiquetaRepository
                        .GetByIdAsync(grupoEtiqueta.EtiquetaId);

                    if (etiqueta == null)
                        throw new InvalidOperationException("Etiqueta não encontrada.");

                    await unitOfWork.GrupoTarefasEtiquetasRepository.AddAsync(new GrupoTarefasEtiquetas
                    {
                        TarefaId = tarefa.Id,
                        EtiquetaId = grupoEtiqueta.EtiquetaId
                    });
                }
            }

            // Responsáveis
            if (request.GrupoTarefaResponsaveis != null && request.GrupoTarefaResponsaveis.Any())
            {
                foreach (var envolvido in request.GrupoTarefaResponsaveis)
                {
                    var usuario = await unitOfWork.UsuarioRepository
                        .GetByIdAsync(envolvido.UsuarioId);

                    if (usuario == null)
                        throw new InvalidOperationException("Usuário não encontrado.");

                    await unitOfWork.GrupoTarefaResponsaveisRepository.AddAsync(new GrupoTarefaResponsaveis
                    {
                        TarefaId = tarefa.Id,
                        UsuarioId = envolvido.UsuarioId
                    });
                }
            }

            await unitOfWork.CommitAsync();

            return mapper.Map<CriarTarefaResponse>(tarefa);
        }

        public async Task ReordenarListaAsync(List<ReordenarListaTarefaRequest> request)
        {
            if (request == null || !request.Any())
                return;

            await unitOfWork.BeginTransactionAsync();

            var ids = request.Select(x => x.Id).ToList();

            var listas = await unitOfWork.ListaTarefaRepository.ObterPorIdsAsync(ids);

            if (listas.Count != request.Count)
                throw new InvalidOperationException("Um ou mais itens não foram encontrados.");

            var requestDict = request.ToDictionary(x => x.Id, x => x.Ordem);

            foreach (var lista in listas)
            {
                lista.Ordem = requestDict[lista.Id];
            }

            await unitOfWork.CommitAsync();
        }

        public Task<PageResult<CriarTarefaResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public async Task<PageResult<TarefaPaginacaoResponse>> ConsultarTarefaPaginacaoAsync(
     int pageNumber,
     int pageSize,
     string? searchTerm = null)
        {
            var paged = await unitOfWork.TarefaRepository
                .GetTarefaPaginacaoAsync(pageNumber, pageSize, searchTerm);

            if (paged == null || !paged.Items.Any())
            {
                return new PageResult<TarefaPaginacaoResponse>
                {
                    Items = new List<TarefaPaginacaoResponse>(),
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

        public Task<CriarTarefaResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CriarTarefaResponse> ModificarAsync(Guid id, TarefaUpdateRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            var tarefa = await unitOfWork.TarefaRepository.GetByIdAsync(id);

            if (tarefa == null)
                throw new InvalidOperationException("Tarefa não encontrada.");

            var usuarioId = ObterUsuarioId();

            // =========================
            // 🔥 SNAPSHOT ANTES
            // =========================
            var dadosAntes = new
            {
                tarefa.Descricao,
                tarefa.DataTarefa,
                tarefa.StatusGeralKanban,
                tarefa.Prioridade,
                tarefa.TipoVinculo,
                tarefa.ProcessoId,
                tarefa.CasoId,
                tarefa.AtendimentoId
            };

            // =========================
            // 🔹 ATUALIZA CAMPOS (PARCIAL)
            // =========================
            if (!string.IsNullOrWhiteSpace(request.Descricao))
                tarefa.Descricao = request.Descricao.Trim();

            if (request.DataTarefa.HasValue)
                tarefa.DataTarefa = request.DataTarefa;

            if (request.Prioridade.HasValue)
                tarefa.Prioridade = request.Prioridade.Value;

            tarefa.DataAtualizacao = DateTime.Now;

            // =========================
            // 🔹 VÍNCULOS (REGRA DE NEGÓCIO)
            // =========================
            int count = 0;
            if (request.ProcessoId.HasValue) count++;
            if (request.CasoId.HasValue) count++;
            if (request.AtendimentoId.HasValue) count++;

            if (count > 1)
                throw new InvalidOperationException("A tarefa não pode ter mais de um vínculo.");

            // limpa tudo
            tarefa.ProcessoId = null;
            tarefa.CasoId = null;
            tarefa.AtendimentoId = null;

            if (request.ProcessoId.HasValue)
            {
                var processo = await unitOfWork.ProcessoRepository.GetByIdAsync(request.ProcessoId.Value)
                    ?? throw new InvalidOperationException("Processo não encontrado.");

                tarefa.ProcessoId = processo.Id;
                tarefa.TipoVinculo = TipoVinculo.Processo;
            }
            else if (request.CasoId.HasValue)
            {
                var caso = await unitOfWork.CasoRepository.GetByIdAsync(request.CasoId.Value)
                    ?? throw new InvalidOperationException("Caso não encontrado.");

                tarefa.CasoId = caso.Id;
                tarefa.TipoVinculo = TipoVinculo.Caso;
            }
            else if (request.AtendimentoId.HasValue)
            {
                var atendimento = await unitOfWork.AtendimentoRepository.GetByIdAsync(request.AtendimentoId.Value)
                    ?? throw new InvalidOperationException("Atendimento não encontrado.");

                tarefa.AtendimentoId = atendimento.Id;
                tarefa.TipoVinculo = TipoVinculo.Atendimento;
            }
            else
            {
                tarefa.TipoVinculo = null;
            }

            // =========================
            // 🔹 CHECKLIST (RESET)
            // =========================
            await unitOfWork.ListaTarefaRepository.RemoverPorTarefaId(id);
            if (request.ListasTarefa?.Any() == true)
            {
                await unitOfWork.ListaTarefaRepository.RemoverPorTarefaId(id);

                int ordem = 0;

                foreach (var item in request.ListasTarefa)
                {
                    if (string.IsNullOrWhiteSpace(item.Descricao))
                        continue;

                    await unitOfWork.ListaTarefaRepository.AddAsync(new ListaTarefa
                    {
                        TarefaId = id,
                        Descricao = item.Descricao.Trim(),
                        Ordem = ordem += 10,
                        Concluida = item.Concluida,
                        DataConclusao = item.Concluida ? DateTime.Now : null
                    });
                }
            }

            // =========================
            // 🔹 ETIQUETAS (RESET)
            // =========================
            await unitOfWork.GrupoTarefasEtiquetasRepository.RemoverPorTarefaId(id);

            if (request.GrupoTarefasEtiquetas?.Any() == true)
            {
                foreach (var item in request.GrupoTarefasEtiquetas)
                {
                    await unitOfWork.GrupoTarefasEtiquetasRepository.AddAsync(new GrupoTarefasEtiquetas
                    {
                        TarefaId = id,
                        EtiquetaId = item.EtiquetaId
                    });
                }
            }

            // =========================
            // 🔹 RESPONSÁVEIS (RESET)
            // =========================
            await unitOfWork.GrupoTarefaResponsaveisRepository.RemoverPorTarefaId(id);

            if (request.GrupoTarefaResponsaveis?.Any() == true)
            {
                foreach (var item in request.GrupoTarefaResponsaveis)
                {
                    await unitOfWork.GrupoTarefaResponsaveisRepository.AddAsync(new GrupoTarefaResponsaveis
                    {
                        TarefaId = id,
                        UsuarioId = item.UsuarioId
                    });
                }
            }

            // =========================
            // 🔥 SNAPSHOT DEPOIS
            // =========================
            var dadosDepois = new
            {
                tarefa.Descricao,
                tarefa.DataTarefa,
                tarefa.StatusGeralKanban,
                tarefa.Prioridade,
                tarefa.TipoVinculo,
                tarefa.ProcessoId,
                tarefa.CasoId,
                tarefa.AtendimentoId
            };

            // =========================
            // 🔥 HISTÓRICO PADRÃO
            // =========================
            await historicoService.RegistrarAsync(
                TipoEntidade.Tarefa,
                tarefa.Id,
                usuarioId,
                dadosAntes,
                dadosDepois,
                "Tarefa atualizada"
            );

            await unitOfWork.CommitAsync();

            return mapper.Map<CriarTarefaResponse>(tarefa);
        }

        public async Task<ObterTarefaResponse?> ObterPorIdAsync(Guid id)
        {
            var tarefa = await unitOfWork.TarefaRepository.ObterCompletoPorIdAsync(id);

            if (tarefa == null)
                return null;

            return mapper.Map<ObterTarefaResponse>(tarefa);
        }
        public async Task MoverCardAsync(MoverKanbanCardRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                if (request.Tipo == "Tarefa")
                {
                    var tarefa = await unitOfWork.TarefaRepository.GetByIdAsync(request.Id);

                    if (tarefa == null)
                        throw new Exception("Tarefa não encontrada");

                    tarefa.StatusGeralKanban = request.NovoStatus;
                    tarefa.DataAtualizacao = DateTime.Now;
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
        public async Task AtualizarStatusTarefasAutomatico()
        {
            var eventos = await unitOfWork.EventoRepository.GetAllAsync();

            var hoje = DateOnly.FromDateTime(DateTime.Now);

            foreach (var evento in eventos)
            {
                if (evento.DataFinal.HasValue && evento.DataFinal < hoje)
                {
                    evento.StatusGeralKanban = StatusGeralKanban.Concluido;
                }
            }

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
        public async Task<List<ListaTarefasResponse>> ConsultarListaTarefaAutoCompleteAsync(string? termo = null)
        {
            return await unitOfWork.ListaTarefaRepository.ConsultarListaTarefaAutoCompleteAsync(termo);
        }

    
    }
}