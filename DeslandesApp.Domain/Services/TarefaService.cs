using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
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

namespace DeslandesApp.Domain.Services
{
    public class TarefaService(IUnitOfWork unitOfWork, IMapper mapper) : ITarefaService
    {
        public async Task<CriarTarefaResponse> AdicionarAsync(CriarTarefaRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            //  DTO -> Entidade
            var tarefa = mapper.Map<Tarefa>(request);

            //  Normalização
            tarefa.Descricao = tarefa.Descricao?.Trim();
            tarefa.DataCadastro = DateTime.Now;

            //  Validação Fluent
            var validator = new TarefaValidator();
            var result = validator.Validate(tarefa);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            //  Salva Tarefa
            await unitOfWork.TarefaRepository.AddAsync(tarefa);

            //  Relacionamentos
            if (request.ListasTarefa != null && request.ListasTarefa.Any())
            {
                foreach (var item in request.ListasTarefa)
                {
                    //  Validação
                    if (item.VinculoId == Guid.Empty)
                        throw new InvalidOperationException("Vínculo é obrigatório.");

                    //  Valida vínculo
                    switch (item.TipoVinculo)
                    {
                        case TipoVinculo.Processo:
                            var processo = await unitOfWork.ProcessoRepository.GetByIdAsync(item.VinculoId);
                            if (processo == null)
                                throw new InvalidOperationException("Processo não encontrado.");
                            break;

                        case TipoVinculo.Atendimento:
                            var atendimento = await unitOfWork.AtendimentoRepository.GetByIdAsync(item.VinculoId);
                            if (atendimento == null)
                                throw new InvalidOperationException("Atendimento não encontrado.");
                            break;

                        case TipoVinculo.Caso:
                            var caso = await unitOfWork.CasoRepository.GetByIdAsync(item.VinculoId);
                            if (caso == null)
                                throw new InvalidOperationException("Caso não encontrado.");
                            break;

                        default:
                            throw new InvalidOperationException("Tipo de vínculo inválido.");
                    }

                    //  Responsável
                    if (item.ResponsavelId.HasValue)
                    {
                        var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(item.ResponsavelId.Value);
                        if (usuario == null)
                            throw new InvalidOperationException("Responsável não encontrado.");
                    }

                    var listaTarefa = new ListaTarefa
                    {
                        TarefaId = tarefa.Id,
                        VinculoId = item.VinculoId,
                        TipoVinculo = item.TipoVinculo,
                        ResponsavelId = item.ResponsavelId,
                        Prioridade = item.Prioridade


                    };

                    await unitOfWork.ListaTarefaRepository.AddAsync(listaTarefa);

                    //  Envolvidos
                    if (item.GrupoTarefaEnvolvido != null && item.GrupoTarefaEnvolvido.Any())
                    {
                        foreach (var envolvido in item.GrupoTarefaEnvolvido)
                        {
                            var usuario = await unitOfWork.UsuarioRepository
                                .GetByIdAsync(envolvido.UsuarioId); // ✅ agora é Guid

                            if (usuario == null)
                                throw new InvalidOperationException("Usuário não encontrado.");

                            var grupo = new GrupoTarefaEnvolvido
                            {
                                ListaTarefaId = listaTarefa.Id,
                                UsuarioId = envolvido.UsuarioId
                            };

                            await unitOfWork.GrupoTarefaEnvolvidoRepository.AddAsync(grupo);
                        }
                    }
                }
            }

            //  Commit
            await unitOfWork.CommitAsync();

            return mapper.Map<CriarTarefaResponse>(tarefa);
        }



        public Task<PageResult<CriarTarefaResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
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
    }
}