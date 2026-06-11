using DeslandesApp.Domain.Models.Entities;
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
  Task<PageResult<ContaPagar>> GetPaginacaoAsync(
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
    }
}
