
using DeslandesApp.Domain.Models.Dtos.Requests.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IProcessoService : IBaseService<ProcessoRequest, ProcessoUpdateRequest, ProcessoResponse, Guid>
    {
        Task<PageResult<ProcessoPaginacaoResponse>> ConsultarProcessoPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null);
        Task<List<ProcessoAutoComplete>> ConsultarProcessoAutoCompleteAsync(string? termo = null);
    }
}