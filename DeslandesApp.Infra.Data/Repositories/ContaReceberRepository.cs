using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
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
                .AsNoTracking()
                .Where(x =>
                    !x.Excluido &&
                    (
                        (!x.Parcelado && x.NumeroParcela == 1)
                        || (x.Parcelado && x.NumeroParcela == 0)
                    ));

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(x =>
                    EF.Functions.Like(x.Descricao, $"%{searchTerm}%") ||
                    EF.Functions.Like(x.Pessoa.Nome, $"%{searchTerm}%"));
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.DataCadastro)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new ContaReceberConsultaResponse
                {
                    Id = x.Id,
                    Cliente = x.Pessoa.Nome,
                    Descricao = x.Descricao,

                    NumeroContrato = x.Contrato != null
                        ? x.Contrato.Numero
                        : string.Empty,

                    ValorTotal = x.Valor,
                    Parcelado = x.Parcelado,
                    TotalParcelas = x.TotalParcelas,
                    FormaRecebimento = x.FormaRecebimento,
                    Status = x.Status,

                    StatusDescricao =
    x.Status == StatusConta.Aberta ? "Pendente" :
    x.Status == StatusConta.Paga ? "Paga" :
    x.Status == StatusConta.Cancelada ? "Cancelada" :
    x.Status == StatusConta.ParcialmentePaga ? "Parcialmente Paga" :
    "-"
                })
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
        public async Task AtualizarContaPaiAsync(Guid contaPaiId, decimal valorPago, decimal valorRecebido,
            StatusConta status, bool quitado, DateTime? dataQuitacao)
        {
            var contaPai = await dataContext.ContaReceber.FirstOrDefaultAsync(x => x.Id == contaPaiId);
            if (contaPai == null)
                return;
            contaPai.ValorPago = valorPago;
            contaPai.ValorRecebido = valorRecebido;
            contaPai.Status = status;
            contaPai.Quitado = quitado;
            contaPai.DataQuitacao = dataQuitacao;
            await dataContext.SaveChangesAsync();
        }
        public async Task<bool> ExistePorContratoAsync(Guid contratoId)
        {
            return await dataContext.ContaReceber
                .AnyAsync(x =>
                    x.ContratoId == contratoId &&
                    x.NumeroParcela == 0 &&
                    !x.Excluido);
        }
        public async Task<bool> ExisteContaPrincipalPorContratoAsync(
    Guid contratoId)
        {
            return await dataContext.ContaReceber
                .AnyAsync(x =>
                    x.ContratoId == contratoId &&
                    x.NumeroParcela == 0);
        }
        public async Task<bool> ExisteDuplicidadeAsync(
    Guid contratoId,
    string descricao,
    decimal valor,
    DateTime dataVencimento)
        {
            return await dataContext.ContaReceber
                .AnyAsync(x =>
                    x.ContratoId == contratoId &&
                    x.Descricao == descricao &&
                    x.Valor == valor &&
                    x.DataVencimento.Date == dataVencimento.Date &&
                    !x.Excluido);
        }
    }
}