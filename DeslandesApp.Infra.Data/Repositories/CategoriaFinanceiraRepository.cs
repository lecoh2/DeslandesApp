using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Responses.CategoriaFinanceira;
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
    public class CategoriaFinanceiraRepository(DataContext dataContext) :
        BaseRepository<CategoriaFinanceira, Guid>(dataContext), ICategoriaFinanceiraRepository
    {
        public async Task<PageResult<CategoriaFinanceiraPaginacaoResponse>> ConsultarCategoriaFinanceiraPaginacaoAsync(
 int pageNumber,
 int pageSize,
 string? searchTerm = null)
        {
            var query = dataContext.CategoriaFinanceira
                .AsNoTracking()
                .Where(x => !x.Excluido)
                .AsQueryable();

            // filtro
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.ToLower();

                query = query.Where(c =>
                    c.Nome.ToLower().Contains(term)
                );
            }

            // total
            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(c => c.Nome)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CategoriaFinanceiraPaginacaoResponse
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Tipo = c.Tipo
                })
                .ToListAsync();

            return new PageResult<CategoriaFinanceiraPaginacaoResponse>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public async Task<List<CategoriaFinanceiraResponse>> ConsultarCategoriaFinanceiraAsync()
        {
            return await dataContext.CategoriaFinanceira
                .AsNoTracking()
                .Where(x => !x.Excluido)
                .OrderBy(x => x.Nome)
                .Select(c => new CategoriaFinanceiraResponse
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Tipo = c.Tipo
                })
                .ToListAsync();
        }
        public async Task<CategoriaFinanceira?> ObterCompletoPorIdAsync(Guid id)
        {
            return await dataContext.CategoriaFinanceira
                .AsNoTracking()
                .Where(x => x.Id == id)

                // =========================
                // USUÁRIO CADASTRO
                // =========================
                .Include(x => x.UsuarioCadastro)

                .FirstOrDefaultAsync();
        }

        public Task<List<CategoriaFinanceiraResponse>> ConsultarAsync()
        {
            throw new NotImplementedException();
        }
    }
}
