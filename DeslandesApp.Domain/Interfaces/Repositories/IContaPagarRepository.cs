using DeslandesApp.Domain.Models.Dtos.Responses.Conta.DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IContaPagarRepository : IBaseRepository<ContaPagar, Guid>
    {
        Task<PageResult<ContaPagarConsultaResponse>> GetPaginacaoAsync(
                int pageNumber,
                int pageSize,
                string? searchTerm = null);
        Task<ContaPagar?> ObterCompletoPorIdAsync(Guid id);
        Task<List<ContaPagar>> ConsultarUltimasAsync(int quantidade);
        Task<int> ContarTotalAsync();
        Task<int> ContarAnoAtualAsync();
        Task<bool> ExisteDuplicidadeAsync(
                 Guid? contratoId,
                 string descricao,
                 decimal valor,
                 DateTime dataVencimento);
        Task AtualizarContaPaiAsync(
    Guid contaPaiId,
    decimal valorPago,
    StatusConta status,
    bool quitado,
    DateTime? dataQuitacao);


    }
}
