using DeslandesApp.Domain.Models.Dtos.Requests.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta.DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IContaPagarService : IBaseService<ContaPagarRequest,ContaPagarUpdateRequest,ContaPagarResponse,Guid>
    {
        Task<List<ContaPagarResponse>> ConsultarAsync();

        Task BaixarAsync(Guid id, ContaPagarBaixaRequest request);
        Task<PageResult<ContaPagarConsultaResponse>> ConsultarPaginacaoAsync(int pageNumber, int pageSize);

        Task<ObterContaPagarResponse?> ObterPorIdAsync(Guid id);

    }
}