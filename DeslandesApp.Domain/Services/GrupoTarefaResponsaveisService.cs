using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoTarefasEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoTarefasResponsaveis;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEnvolvidosProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoTarefaResponsaveis;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class GrupoTarefaResponsaveisServices(IUnitOfWork unitOfWork, IMapper mapper) : IGrupoTarefaResponsaveisService
    {
        public Task<GrupoTarefaResponsaveisResponse> AdicionarAsync(GrupoTarefaResponsaveisRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoTarefaResponsaveisResponse> AdicionarTarefaResponaveisAsync(Guid idUsuario, Guid idTarefa)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var pessoa = await unitOfWork.UsuarioRepository.GetByIdAsync(idUsuario);
                if (pessoa is null)
                    throw new ApplicationException("Pessoa não encontrado.");

                var tarefa = await unitOfWork.TarefaRepository.GetByIdAsync(idTarefa);
                if (tarefa is null)
                    throw new ApplicationException("Tarefa não encontrado.");

                var existeVinculo = await unitOfWork.GrupoTarefaResponsaveisRepository
                    .ExistTarefaResponsaveisAsync(idUsuario, idTarefa);

                if (existeVinculo != null)
                    throw new ApplicationException("Esta tarefa já está vinculada a essa pessoa.");

                var grupoTarefaResponsaveis = new GrupoTarefaResponsaveis
                {
                    TarefaId = idTarefa,
                    UsuarioId = idUsuario
                };

                await unitOfWork.GrupoTarefaResponsaveisRepository.AddAsync(grupoTarefaResponsaveis);

                await unitOfWork.CommitAsync();

                return new GrupoTarefaResponsaveisResponse(
                   pessoa.Id,
                   tarefa.Id,
                   pessoa.NomeUsuario // 👈 aqui

               );
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task<PageResult<GrupoTarefaResponsaveisResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<GrupoTarefaResponsaveisResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoTarefaResponsaveisResponse> ModificarAsync(Guid id, GrupoTarefaResponsaveisUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoTarefaResponsaveisResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoTarefaResponsaveisResponse> RemoverTarefaResponsaveisAsync(Guid idPessoa, Guid idTarefa)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entidade = await unitOfWork.GrupoTarefaResponsaveisRepository
                    .GetByIdTarefaResponsaveisAsync(idPessoa, idTarefa);

                if (entidade is null)
                    throw new Exception("Vínculo entre Processo e Etiqueta não encontrado.");

                await unitOfWork.GrupoTarefaResponsaveisRepository.DeleteAsync(entidade);

                await unitOfWork.CommitAsync();
                return new GrupoTarefaResponsaveisResponse(
    entidade.UsuarioId,
    entidade.TarefaId,
    entidade.Usuario?.NomeUsuario
);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw; // 🔥 ESSENCIAL pro middleware funcionar
            }
        }
    }
}
