using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Responses.Contrato;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class ContratoRepository(DataContext dataContext)
        : BaseRepository<Contrato, Guid>(dataContext),
          IContratoRepository
    {
        public async Task<PageResult<ContratoPaginacaoResponse>> ConsultarContratoPaginacaoAsync(
    int pageNumber,
    int pageSize,
    string? searchTerm = null)
        {
            var query = dataContext.Contrato
                .AsNoTracking()
                .Include(x => x.Pessoa)
                .AsQueryable();

            // --- filtro ---
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.ToLower();

                query = query.Where(c =>
                    c.Numero.ToLower().Contains(term) ||
                    c.Pessoa.Nome.ToLower().Contains(term)
                );
            }

            // --- total ---
            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(c => c.Numero)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new ContratoPaginacaoResponse
                {
                    Id = c.Id,
                    Numero = c.Numero,
                    PessoaId = c.PessoaId,
                    NomePessoa = c.Pessoa.Nome,
                    ValorContrato = c.ValorTotal ?? 0,
                    DataInicio = c.DataInicio,
                    DataFim = c.DataFim
                })
                .ToListAsync();

            return new PageResult<ContratoPaginacaoResponse>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}