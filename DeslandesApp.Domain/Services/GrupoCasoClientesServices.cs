using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoClienteProcesso;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class GrupoCasoClientesServices(IUnitOfWork unitOfWork, IMapper mapper) : IGrupoCasoClienteService
    {
        public Task<GrupoCasoClienteResponse> AdicionarAsync(GrupoCasoClienteRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoCasoClienteResponse> AdicionarGrupoCasoClienteAsync(Guid idPessoa, Guid idCaso)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var pessoa = await unitOfWork.PessoaRepository.GetByIdAsync(idPessoa);
                if (pessoa is null)
                    throw new ApplicationException("Pessoa não encontrada.");

                var caso = await unitOfWork.CasoRepository.GetByIdAsync(idCaso);
                if (caso is null)
                    throw new ApplicationException("Caso não encontrado.");

                var existeVinculo = await unitOfWork.GrupoCasoClienteRepository
                    .ExistCasoClienteAsync(idPessoa, idCaso);

                if (existeVinculo != null)
                    throw new ApplicationException("Este usuário já está vinculado a esse processo.");

                var grupoCasoCliente = new GrupoCasoCliente
                {
                    PessoaId = idPessoa,
                    CasoId = idCaso
                };

                await unitOfWork.GrupoCasoClienteRepository.AddAsync(grupoCasoCliente);

                await unitOfWork.CommitAsync();

                return new GrupoCasoClienteResponse
                {
                    PessoaId = pessoa.Id,
                    CasoId = caso.Id,
                    Nome = pessoa.Nome
                };
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task<PageResult<GrupoCasoClienteResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<GrupoCasoClienteResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoCasoClienteResponse> ModificarAsync(Guid id, GrupoCasoClienteUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoCasoClienteResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoCasoClienteResponse> RemoverGrupoCasoClienteAsync(Guid idPessoa, Guid idProcesso)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entidade = await unitOfWork.GrupoCasoClienteRepository
                    .GetByIdClienteAsync(idPessoa, idProcesso);

                if (entidade is null)
                    throw new Exception("Vínculo entre caso e Pessoa não encontrado.");

                await unitOfWork.GrupoCasoClienteRepository.DeleteAsync(entidade);

                await unitOfWork.CommitAsync();
                return new GrupoCasoClienteResponse
                {
                    PessoaId = entidade.PessoaId,
                    CasoId = entidade.CasoId,
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
