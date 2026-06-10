using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class BaixaFinanceiraRepository(DataContext dataContext)
          : BaseRepository<BaixaFinanceira, Guid>(dataContext), IBaixaFinanceiraRepository
    {
        public async Task<List<BaixaFinanceira>> ConsultarPorPeriodoAsync(
              DateTime dataInicio,
              DateTime dataFim)
        {
            return await dataContext.BaixaFinanceira
                .AsNoTracking()
                .Include(x => x.FormaPagamento)
                .Include(x => x.ContaReceber)
                .Include(x => x.ContaPagar)
                .Where(x =>
                    x.DataBaixa >= dataInicio &&
                    x.DataBaixa <= dataFim)
                .OrderByDescending(x => x.DataBaixa)
                .ToListAsync();
        }

        public async Task<List<BaixaFinanceira>> ObterPorContaReceberAsync(
            Guid contaReceberId)
        {
            return await dataContext.BaixaFinanceira
                .AsNoTracking()
                .Include(x => x.FormaPagamento)
                .Where(x => x.ContaReceberId == contaReceberId)
                .OrderByDescending(x => x.DataBaixa)
                .ToListAsync();
        }

        public async Task<List<BaixaFinanceira>> ObterPorContaPagarAsync(
            Guid contaPagarId)
        {
            return await dataContext.BaixaFinanceira
                .AsNoTracking()
                .Include(x => x.FormaPagamento)
                .Where(x => x.ContaPagarId == contaPagarId)
                .OrderByDescending(x => x.DataBaixa)
                .ToListAsync();
        }

        public async Task<BaixaFinanceira?> ObterCompletaPorIdAsync(
            Guid id)
        {
            return await dataContext.BaixaFinanceira
                .AsNoTracking()
                .Include(x => x.FormaPagamento)
                .Include(x => x.ContaReceber)
                .Include(x => x.ContaPagar)
                .Include(x => x.ContaBancariaEmpresa)
                .FirstOrDefaultAsync(x => x.Id == id);
        }




    }
}
