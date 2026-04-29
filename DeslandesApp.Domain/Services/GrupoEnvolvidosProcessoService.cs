using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEnvolvidosProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoClienteProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEnvolvidosProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetasProcessos;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class GrupoEnvolvidosProcessoService(IUnitOfWork unitOfWork, IMapper mapper) : IGrupoEnvolvidosProcessoService
    {
        public Task<GrupoEnvolvidosProcessoResponse> AdicionarAsync(GrupoEnvolvidosProcessoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoEnvolvidosProcessoResponse> AdicionarEnvolvidosProcessoAsync(Guid idPessoa, Guid idProcesso)
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

                var existeVinculo = await unitOfWork.GrupoEnvolvidosProcessosRepository
                    .ExistEnvolvidosProcessoAsync(idPessoa, idProcesso);

                if (existeVinculo != null)
                    throw new ApplicationException("Este usuário já está vinculado a esse processo.");

                var grupoEnvolvidosProcesso = new GrupoEnvolvidosProcesso
                {
                    PessoaId = idPessoa,
                    ProcessoId = idProcesso
                };

                await unitOfWork.GrupoEnvolvidosProcessosRepository.AddAsync(grupoEnvolvidosProcesso);

                await unitOfWork.CommitAsync();

                return new GrupoEnvolvidosProcessoResponse
                {
                    IdPessoa = pessoa.Id,
                    IdProcesso = processo.Id,
                    Nome = pessoa.Nome
                };


            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task<PageResult<GrupoEnvolvidosProcessoResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<GrupoEnvolvidosProcessoResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoEnvolvidosProcessoResponse> ModificarAsync(Guid id, GrupoEnvolvidosProcessoUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoEnvolvidosProcessoResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoEnvolvidosProcessoResponse> RemoverEnvolvidosProcessoAsync(Guid idPessoa, Guid idProcesso)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entidade = await unitOfWork.GrupoEnvolvidosProcessosRepository
                    .GetByIdEnvolvidosProcessoAsync(idPessoa, idProcesso);

                if (entidade is null)
                    throw new Exception("Vínculo entre Processo e Pessoa não encontrado.");

                await unitOfWork.GrupoEnvolvidosProcessosRepository.DeleteAsync(entidade);

                await unitOfWork.CommitAsync();
                return new GrupoEnvolvidosProcessoResponse
                {
                    IdPessoa = entidade.PessoaId,
                    IdProcesso = entidade.ProcessoId,
                    Nome = entidade.Pessoa?.Nome
                };
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw; // 🔥 ESSENCIAL pro middleware funcionar
            }
        }
    }
}
