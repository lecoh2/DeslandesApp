using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class ContaPagarService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
    ) : BaseService(httpContextAccessor), IContaPagarService
    {
        public async Task<ContaPagar> AdicionarAsync(ContaPagar conta)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                conta.Status = StatusConta.Aberta;
                conta.DataCadastro = DateTime.Now;

                await unitOfWork.ContaPagarRepository.AddAsync(conta);

                await unitOfWork.CommitAsync();

                return conta;
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task<ContaPagarResponse> AdicionarAsync(ContaPagarRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task BaixarAsync(Guid id, decimal valorPago)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var conta = await unitOfWork
                    .ContaPagarRepository
                    .GetByIdAsync(id);

                if (conta == null)
                    throw new ApplicationException("Conta não encontrada.");

                conta.ValorPago += valorPago;

                conta.Status = conta.ValorPago >= conta.Valor
                    ? StatusConta.Paga
                    : StatusConta.ParcialmentePaga;

                await unitOfWork
                    .ContaPagarRepository
                    .UpdateAsync(conta);

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task BaixarAsync(Guid id, ContaPagarUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContaPagarResponse>> ConsultarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<ContaPagarResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<ContaPagarResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ContaPagarResponse> ModificarAsync(Guid id, ContaPagarUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
