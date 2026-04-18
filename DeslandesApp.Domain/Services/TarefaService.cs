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

namespace DeslandesApp.Domain.Services
{
    public class TarefaService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : ITarefaService
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
            tarefa.StatusGeralKanban = StatusGeralKanban.A_Fazer;
            // Responsável
           // tarefa.ResponsavelId = request.ResponsavelId;
            tarefa.UsuarioCriacaoId = ObterUsuarioId();

            // 🔗 VALIDAÇÃO DE VÍNCULOS OPCIONAIS
            int count = 0;
            if (request.ProcessoId.HasValue) count++;
            if (request.CasoId.HasValue) count++;
            if (request.AtendimentoId.HasValue) count++;

            if (count > 1)
                throw new InvalidOperationException("A tarefa não pode ter mais de um vínculo.");

            // RESOLVE VÍNCULO AUTOMATICAMENTE
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
                var atendimentoPai = await unitOfWork.AtendimentoRepository.GetByIdAsync(request.AtendimentoId.Value);
                if (atendimentoPai == null)
                    throw new InvalidOperationException("Atendimento pai não encontrado.");

                tarefa.AtendimentoId = atendimentoPai.Id;
                tarefa.TipoVinculo = TipoVinculo.Atendimento;
            }
            else
            {
                tarefa.TipoVinculo = null; // TipoVinculo agora deve ser nullable
            }

            // Validação Fluent
            var validator = new TarefaValidator();
            var result = validator.Validate(tarefa);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            // Valida responsável
            if (tarefa.UsuarioCriacaoId.HasValue)
            {
                var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(tarefa.UsuarioCriacaoId.Value);
                if (usuario == null)
                    throw new InvalidOperationException("Responsável não encontrado.");
            }

            // Salva tarefa
            await unitOfWork.TarefaRepository.AddAsync(tarefa);

            // Checklist
            if (request.ListasTarefa != null && request.ListasTarefa.Any())
            {
                var ultimaOrdem = await unitOfWork.ListaTarefaRepository
     .ObterMaiorOrdemPorTarefaId(tarefa.Id) ?? 0;

                int incremento = 0;

                foreach (var item in request.ListasTarefa)
                {
                    incremento += 10;

                    var lista = new ListaTarefa
                    {
                        TarefaId = tarefa.Id,
                        Descricao = item.Descricao?.Trim(),
                        Ordem = ultimaOrdem + incremento
                    };

                    await unitOfWork.ListaTarefaRepository.AddAsync(lista);
                }
            }

            // Etiquetas (N:N)
            // 🏷️ ETIQUETAS (N:N)
            if (request.GrupoTarefasEtiquetas != null && request.GrupoTarefasEtiquetas.Any())
            {
                foreach (var grupoEtiqueta in request.GrupoTarefasEtiquetas)
                {
                    var etiqueta = await unitOfWork.EtiquetaRepository.GetByIdAsync(grupoEtiqueta.EtiquetaId);
                    if (etiqueta == null) throw new InvalidOperationException("Etiqueta não encontrada.");
                    var grupotarefasEtiquetas = new GrupoTarefasEtiquetas
                    {
                        TarefaId = tarefa.Id,
                        EtiquetaId = grupoEtiqueta.EtiquetaId
                    };
                    await unitOfWork.GrupoTarefasEtiquetasRepository.AddAsync(grupotarefasEtiquetas);
                }
            }

            // Envolvidos (N:N)
            if (request.GrupoTarefaResponsaveis != null && request.GrupoTarefaResponsaveis.Any())
            {
                foreach (var envolvido in request.GrupoTarefaResponsaveis)
                {
                    var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(envolvido.UsuarioId);
                    if (usuario == null)
                        throw new InvalidOperationException("Usuário não encontrado.");

                    var grupo = new GrupoTarefaResponsaveis
                    {
                        TarefaId = tarefa.Id,
                        UsuarioId = envolvido.UsuarioId
                    };
                    await unitOfWork.GrupoTarefaResponsaveisRepository.AddAsync(grupo);
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

        public Task<CriarTarefaResponse> ModificarAsync(Guid id, TarefaUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CriarTarefaResponse?> ObterPorIdAsync(Guid id)
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
    }
}