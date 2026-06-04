using DeslandesApp.Domain.Models.Dtos.Responses.Contrato;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IContratoRepository
        : IBaseRepository<Contrato, Guid>
    {
         Task<PageResult<ContratoPaginacaoResponse>> ConsultarContratoPaginacaoAsync(
   int pageNumber,
   int pageSize,
   string? searchTerm = null);
        Task<Contrato?> ObterCompletoPorIdAsync(Guid id);
    }
}