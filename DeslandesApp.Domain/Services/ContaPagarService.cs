using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
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
    ) : BaseService(httpContextAccessor)
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
    }
}
