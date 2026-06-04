using DeslandesApp.Domain.Models.Dtos.Requests.Contrato;
using DeslandesApp.Domain.Models.Dtos.Responses.Contrato;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Utils;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IContratoService :
        IBaseService<
            ContratoRequest,
            ContratoUpdateRequest,
            ContratoResponse,
            Guid>
    {
        Task<List<ContratoResponse>> ConsultarAsync();
        Task<PageResult<ContratoPaginacaoResponse>> ConsultarContratoPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null);
        Task<ObterContratoResponse?> ObterPorIdAsync(Guid id);
       
     
    }
}