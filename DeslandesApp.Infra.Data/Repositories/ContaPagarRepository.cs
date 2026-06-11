using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Infra.Data.Contexts;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class ContaPagarRepository(DataContext dataContext)
          : BaseRepository<ContaPagar, Guid>(dataContext), IContaPagarRepository
    {
        public async Task<PageResult<ContaPagar>> GetPaginacaoAsync(
             int pageNumber,
             int pageSize,
             string? searchTerm = null)
        {
            var query = dataContext.ContaPagar
                .AsNoTracking()
                .Include(x => x.Pessoa)
                .Include(x => x.Contrato)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.ToLower();

                query = query.Where(x =>
                    x.Descricao.ToLower().Contains(term) ||
                    x.Pessoa.Nome.ToLower().Contains(term)
                );
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.DataVencimento)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageResult<ContaPagar>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<List<ContaPagar>> ConsultarComRelacionamentosAsync()
        {
            return await dataContext.ContaPagar
                .AsNoTracking()
                .Include(x => x.Pessoa)
                .Include(x => x.Contrato)
                .Include(x => x.CategoriaFinanceira)
                .ToListAsync();
        }

        public async Task<ContaPagar?> ObterCompletoPorIdAsync(Guid id)
        {
            return await dataContext.ContaPagar
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Pessoa)
                .Include(x => x.Contrato)
                .Include(x => x.CategoriaFinanceira)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ContaPagar>> ConsultarUltimasAsync(int quantidade)
        {
            return await dataContext.ContaPagar
                .OrderByDescending(x => x.DataVencimento)
                .Take(quantidade)
                .ToListAsync();
        }

        public async Task<int> ContarTotalAsync()
        {
            return await dataContext.ContaPagar.CountAsync();
        }

        public async Task<int> ContarAnoAtualAsync()
        {
            var inicioAno = new DateTime(DateTime.Now.Year, 1, 1);
            var fimAno = new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59);

            return await dataContext.ContaPagar
                .Where(x => x.DataVencimento >= inicioAno && x.DataVencimento <= fimAno)
                .CountAsync();
        }

        public async Task<bool> ExisteDuplicidadeAsync(
         Guid? contratoId,
         string descricao,
         decimal valor,
         DateTime dataVencimento)
        {
            return await dataContext.ContaPagar
                .AnyAsync(x =>
                    x.ContratoId == contratoId &&
                    x.Descricao == descricao &&
                    Math.Abs(x.Valor - valor) < 0.01m &&
                    x.DataVencimento.Date == dataVencimento.Date &&
                    !x.Excluido);
        }
    }
}