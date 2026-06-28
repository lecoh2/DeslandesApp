using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.DashboardFinanceiro;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IBaixaFinanceiraRepository : IBaseRepository<BaixaFinanceira, Guid>
    {

        Task<List<BaixaFinanceira>> ObterPorContaReceberAsync(
            Guid contaReceberId);

        Task<List<BaixaFinanceira>> ObterPorContaPagarAsync(
            Guid contaPagarId);

        Task<List<BaixaFinanceira>> ConsultarPorPeriodoAsync(
            DateTime dataInicio,
            DateTime dataFim);

        Task<List<MovimentacaoFinanceiraResponse>>
            ObterUltimasMovimentacoesAsync(
                int quantidade = 10);
    }





    }
