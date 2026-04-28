using DeslandesApp.Domain.Models.Dtos.Requests.Caso;
using DeslandesApp.Domain.Models.Dtos.Requests.Tarefa;
using DeslandesApp.Domain.Models.Dtos.Responses.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Tarefa;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface ICasoService : IBaseService<CriarCasoRequest, CasoUpdateRequest, CriarCasoResponse, Guid>
    {
        Task<PageResult<CasoPaginacaoResponse>> ConsultarCasoPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null);
        Task<List<CasoAutoComplete>> ConsultarCasoAutoCompleteAsync(string? termo = null);
        Task<ObterCasoResponse?> ObterPorIdAsync(Guid id);
    }
}
