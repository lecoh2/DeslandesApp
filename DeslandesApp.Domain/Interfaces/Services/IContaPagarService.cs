using DeslandesApp.Domain.Models.Dtos.Requests.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta.DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Utils;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IContaPagarService :
        IBaseService<
            ContaPagarRequest,
            ContaPagarUpdateRequest,
            ContaPagarResponse,
            Guid>
    {
        Task<List<ContaReceberConsultaResponse>> ConsultarAsync();

        Task BaixarAsync(
            Guid id,
            ContaPagarUpdateRequest request
        );

        Task<PageResult<ContaPagarResponse>> ConsultarAsync(int pageNumber, int pageSize);
    }
}