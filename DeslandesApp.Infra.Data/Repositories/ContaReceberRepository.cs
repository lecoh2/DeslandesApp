using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class ContaReceberRepository(DataContext dataContext)
        : BaseRepository<ContaReceber, Guid>(dataContext), IContaReceberRepository
    {
        public async Task<PageResult<ContaReceberConsultaResponse>> GetPaginacaoAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm = null)
        {
            var query = dataContext.ContaReceber
                .Include(x => x.Pessoa)
                .Include(x => x.Contrato)
                .AsNoTracking()
                .Where(x =>
                    x.NumeroParcela > 0 &&
                    !x.Excluido);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.ToLower();

                query = query.Where(x =>
                    x.Descricao.ToLower().Contains(term) ||
                    x.Pessoa.Nome.ToLower().Contains(term));
            }

            var agrupado = query
                .GroupBy(x => x.ContratoId)
                .Select(g => new ContaReceberConsultaResponse
                {
                    Id = g.First().Id,

                    Cliente = g.First().Pessoa.Nome,

                    Descricao = g.First().Descricao,

                    NumeroContrato = g.First().Contrato != null
                        ? g.First().Contrato.Numero
                        : string.Empty,

                    ValorTotal = g.Sum(x => x.Valor),

                    Parcelado = g.First().Parcelado,

                    TotalParcelas = g.First().TotalParcelas,

                    FormaRecebimento = g.First().FormaRecebimento
                });

            var totalCount = await agrupado.CountAsync();

            var items = await agrupado
                .OrderBy(x => x.Cliente)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageResult<ContaReceberConsultaResponse>
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
            var conta = await dataContext.ContaReceber
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (conta == null)
                return null;

            var idPrincipal = conta.ContaPaiId ?? conta.Id;

            return await dataContext.ContaReceber
              .AsNoTracking()
              .Include(x => x.Pessoa)
              .Include(x => x.Contrato)
              .Include(x => x.CategoriaFinanceira)
              .Include(x => x.CentroCusto)
              .Include(x => x.Baixas)
              .Include(x => x.Parcelas.OrderBy(p => p.NumeroParcela))
              .FirstOrDefaultAsync(x => x.Id == idPrincipal);
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