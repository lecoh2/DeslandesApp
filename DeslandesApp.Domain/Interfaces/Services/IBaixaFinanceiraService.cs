using DeslandesApp.Domain.Models.Dtos.Requests.BaixaFinanceira;
using DeslandesApp.Domain.Models.Dtos.Responses.BaixaFinanceira;
using DeslandesApp.Domain.Models.Dtos.Responses.DashboardFinanceiro;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IBaixaFinanceiraService : IBaseService<BaixaFinanceiraRequest, BaixaFinanceiraUpdateRequest, BaixaFinanceiraResponse, Guid>
    {
        Task<List<BaixaFinanceiraResponse>> ConsultarAsync();
      

        Task<BaixaFinanceiraResponse?>
            ObterPorIdAsync(Guid id);
        Task<List<BaixaFinanceiraResponse>> ConsultarPorContaReceberAsync(
    Guid contaReceberId);

        Task<List<BaixaFinanceiraResponse>> ConsultarPorContaPagarAsync(
            Guid contaPagarId);
        Task<List<MovimentacaoFinanceiraResponse>>
    ObterUltimasMovimentacoesAsync(
        int quantidade = 10);
    }
}
