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

            // DTO -> Entidade
            var tarefa = mapper.Map<Tarefa>(request);

            // Normalização
            tarefa.Descricao = tarefa.Descricao?.Trim();
            tarefa.DataCadastro = DateTime.Now;
            tarefa.DataAtualizacao = DateTime.Now;

            // Responsável
            tarefa.ResponsavelId = request.ResponsavelId;

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
            if (tarefa.ResponsavelId.HasValue)
            {
                var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(tarefa.ResponsavelId.Value);
                if (usuario == null)
                    throw new InvalidOperationException("Responsável não encontrado.");
            }

            // Salva tarefa
            await unitOfWork.TarefaRepository.AddAsync(tarefa);

            // Checklist
            if (request.ListasTarefa != null && request.ListasTarefa.Any())
            {
                foreach (var item in request.ListasTarefa)
                {
                    var lista = new ListaTarefa
                    {
                        TarefaId = tarefa.Id,
                        Descricao = item.Descricao?.Trim(),
                        Ordem = item.Ordem
                    };
                    await unitOfWork.ListaTarefaRepository.AddAsync(lista);
                }
            }

            // Etiquetas (N:N)
            // 🏷️ ETIQUETAS (N:N)
            if (request.Etiquetas != null && request.Etiquetas.Any())
            {
                foreach (var grupoEtiqueta in request.Etiquetas)
                {
                    var etiqueta = await unitOfWork.EtiquetaRepository.GetByIdAsync(grupoEtiqueta.EtiquetaId);
                    if (etiqueta == null) throw new InvalidOperationException("Etiqueta não encontrada.");
                    var tarefaEtiqueta = new TarefaEtiqueta
                    {
                        TarefaId = tarefa.Id,
                        EtiquetaId = grupoEtiqueta.EtiquetaId
                    };
                    await unitOfWork.TarefaEtiquetaRepository.AddAsync(tarefaEtiqueta);
                }
            }

            // Envolvidos (N:N)
            if (request.GrupoTarefaEnvolvido != null && request.GrupoTarefaEnvolvido.Any())
            {
                foreach (var envolvido in request.GrupoTarefaEnvolvido)
                {
                    var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(envolvido.UsuarioId);
                    if (usuario == null)
                        throw new InvalidOperationException("Usuário não encontrado.");

                    var grupo = new GrupoTarefaEnvolvido
                    {
                        TarefaId = tarefa.Id,
                        UsuarioId = envolvido.UsuarioId
                    };
                    await unitOfWork.GrupoTarefaEnvolvidoRepository.AddAsync(grupo);
                }
            }

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