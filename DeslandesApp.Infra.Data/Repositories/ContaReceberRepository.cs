using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class ContaReceberRepository(DataContext dataContext)
        : BaseRepository<ContaReceber, Guid>(dataContext), IContaReceberRepository
    {
        public async Task<PageResult<ContaReceber>> GetPaginacaoAsync(
    int pageNumber,
    int pageSize,
    string? searchTerm = null)
        {
            var query = dataContext.ContaReceber
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.ToLower();

                query = query.Where(x =>
                    x.Descricao.ToLower().Contains(term) ||
                    x.Pessoa.Nome.ToLower().Contains(term) ||   // 👈 AQUI AJUSTADO
                    x.Contrato.Numero.ToLower().Contains(term)
                );
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.DataVencimento)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageResult<ContaReceber>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<List<ContaReceber>> ConsultarComRelacionamentosAsync()
        {
            return await dataContext.ContaReceber
                .AsNoTracking()
                .Include(x => x.Pessoa)     // 👈 AJUSTADO
                .Include(x => x.Contrato)
                .ToListAsync();
        }
        public async Task<ContaReceber?> ObterCompletoPorIdAsync(Guid id)
        {
            return await dataContext.ContaReceber
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Pessoa)     // 👈 AJUSTADO
                .Include(x => x.Contrato)
                .FirstOrDefaultAsync();
        }
        public async Task<List<ContaReceber>> ConsultarUltimasAsync(int quantidade)
        {
            return await dataContext.ContaReceber
                .OrderByDescending(x => x.DataVencimento)
                .Take(quantidade)
                .ToListAsync();
        }
        public async Task<int> ContarTotalAsync()
        {
            return await dataContext.ContaReceber.CountAsync();
        }

        public async Task<int> ContarAnoAtualAsync()
        {
            var inicioAno = new DateTime(DateTime.Now.Year, 1, 1);
            var fimAno = new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59);

            return await dataContext.ContaReceber
                .Where(x => x.DataVencimento >= inicioAno && x.DataVencimento <= fimAno)
                .CountAsync();
        }
    }
}