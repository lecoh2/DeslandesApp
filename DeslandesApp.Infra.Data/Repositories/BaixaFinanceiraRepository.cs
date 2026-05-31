using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
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
                .Where(x => x.DataBaixa >= dataInicio && x.DataBaixa <= dataFim)
                .ToListAsync();
        }
    }
}