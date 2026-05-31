using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class BaixaFinanceiraService(
         IUnitOfWork unitOfWork)
    {
        public async Task<BaixaFinanceira> AdicionarAsync(BaixaFinanceira baixa)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                baixa.DataCadastro = DateTime.Now;

                await unitOfWork.BaixaFinanceiraRepository
                    .AddAsync(baixa);

                await unitOfWork.CommitAsync();

                return baixa;
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
