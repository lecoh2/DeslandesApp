using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IContaReceberRepository : IBaseRepository<ContaReceber, Guid>
    {
        Task<PageResult<ContaReceber>> GetPaginacaoAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm = null);

        Task<List<ContaReceber>> ConsultarComRelacionamentosAsync();

        Task<ContaReceber?> ObterCompletoPorIdAsync(Guid id);

        Task<List<ContaReceber>> ConsultarUltimasAsync(int quantidade);

        Task<int> ContarTotalAsync();

        Task<int> ContarAnoAtualAsync();
    }
}