using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.DashboardFinanceiro;
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
                .Include(x => x.ContaReceber)
                .Where(x => x.ContaReceberId == contaReceberId)
                .OrderByDescending(x => x.DataBaixa)
                .ToListAsync();
        }

        public async Task<List<BaixaFinanceira>> ObterPorContaPagarAsync(
            Guid contaPagarId)
        {
            return await dataContext.BaixaFinanceira
                .AsNoTracking()
                .Include(x => x.ContaPagar)
                .Where(x => x.ContaPagarId == contaPagarId)
                .OrderByDescending(x => x.DataBaixa)
                .ToListAsync();
        }

        public async Task<BaixaFinanceira?> ObterCompletaPorIdAsync(
            Guid id)
        {
            return await dataContext.BaixaFinanceira
                .AsNoTracking()
                .Include(x => x.ContaReceber)
                .ThenInclude(x => x.Pessoa)
                .Include(x => x.ContaPagar)
                .ThenInclude(x => x.Pessoa)
                .Include(x => x.ContaBancariaEmpresa)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<MovimentacaoFinanceiraResponse>>
      ObterUltimasMovimentacoesAsync(
          int quantidade = 10)
        {
            return await dataContext.BaixaFinanceira
                .AsNoTracking()
                .Include(x => x.ContaReceber)
                    .ThenInclude(x => x.Pessoa)
                .Include(x => x.ContaPagar)
                    .ThenInclude(x => x.Pessoa)
                .OrderByDescending(x => x.DataBaixa)
                .Take(quantidade)
                .Select(x => new MovimentacaoFinanceiraResponse
                {
                    Data = x.DataBaixa,

                    Descricao =
                        x.ContaReceber != null
                            ? x.ContaReceber.Descricao
                            : x.ContaPagar!.Descricao,

                    Pessoa =
                        x.ContaReceber != null
                            ? x.ContaReceber.Pessoa.Nome
                            : x.ContaPagar!.Pessoa.Nome,

                    Valor = x.ValorPago,

                    Tipo =
                        x.ContaReceberId != null
                            ? "Receita"
                            : "Despesa"
                })
                .ToListAsync();
        }
    }




}

