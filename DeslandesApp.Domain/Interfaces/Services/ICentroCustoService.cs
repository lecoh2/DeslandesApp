using DeslandesApp.Domain.Models.Dtos.Requests.CentroCusto;
using DeslandesApp.Domain.Models.Dtos.Responses.CentroCusto;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface ICentroCustoService :
        IBaseService<
            CentroCustoRequest,
            CentroCustoUpdateRequest,
            CentroCustoResponse,
            Guid>
    {
        Task<List<CentroCustoResponse>> ConsultarAsync();
        Task<ObterCentroCustoResponse?> ObterPorIdAsync(Guid id);
    }
}
