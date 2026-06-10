
using DeslandesApp.Domain.Models.Dtos.Requests.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Utils;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IContaReceberService :
        IBaseService<ContaReceberRequest, ContaReceberUpdateRequest, ContaReceberResponse, Guid>
    {
        Task<List<ContaReceberResponse>> ConsultarAsync();

        Task BaixarAsync(Guid id, ContaReceberBaixaRequest request);
        Task<PageResult<ContaReceberConsultaResponse>> ConsultarPaginacaoAsync(int pageNumber, int pageSize);

        Task<ObterContaReceberResponse?> ObterPorIdAsync(Guid id);

    }
}