using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoClienteProceso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoClienteProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEnvolvidosProcesso;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class GrupoClienteProcessoService(IUnitOfWork unitOfWork, IMapper mapper) : IGrupoClienteProcessoService
    {
        public Task<GrupoClienteProcessoResponse> AdicionarAsync(GrupoClienteProcessoRequest request)
        {
            throw new NotImplementedException();
        }



        public async Task<GrupoClienteProcessoResponse> AdicionarClienteProcessoAsync(Guid idPessoa, Guid idProcesso)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var pessoa = await unitOfWork.PessoaRepository.GetByIdAsync(idPessoa);
                if (pessoa is null)
                    throw new ApplicationException("Pessoa não encontrada.");

                var processo = await unitOfWork.ProcessoRepository.GetByIdAsync(idProcesso);
                if (processo is null)
                    throw new ApplicationException("Processo não encontrado.");

                var existeVinculo = await unitOfWork.GrupoClientesProcessosRepository
                    .ExistClienteProcessoAsync(idPessoa, idProcesso);

                if (existeVinculo != null)
                    throw new ApplicationException("Este usuário já está vinculado a esse processo.");

                var grupoClienteProcesso = new GrupoClienteProcesso
                {
                    PessoaId = idPessoa,
                    ProcessoId = idProcesso
                };

                await unitOfWork.GrupoClientesProcessosRepository.AddAsync(grupoClienteProcesso);

                await unitOfWork.CommitAsync();

                return new GrupoClienteProcessoResponse(
                    pessoa.Id,
                     processo.Id,
                    pessoa.Nome // 👈 aqui

                );
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task<GrupoClienteProcessoResponse> RemoverClienteProcessoAsync(Guid idPessoa, Guid idProcesso)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entidade = await unitOfWork.GrupoClientesProcessosRepository
                    .GetByIdClienteProcessoAsync(idPessoa, idProcesso);

                if (entidade is null)
                    throw new Exception("Vínculo entre Processo e Pessoa não encontrado.");

                await unitOfWork.GrupoClientesProcessosRepository.DeleteAsync(entidade);

                await unitOfWork.CommitAsync();
                return new GrupoClienteProcessoResponse(
entidade.PessoaId,
entidade.ProcessoId,
entidade.Pessoa?.Nome
);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw; // 🔥 ESSENCIAL pro middleware funcionar
            }
        }
        public Task<PageResult<GrupoClienteProcessoResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<GrupoClienteProcessoResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoClienteProcessoResponse> ModificarAsync(Guid id, GrupoClienteProcessoUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoClienteProcessoResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

       
    }
}
