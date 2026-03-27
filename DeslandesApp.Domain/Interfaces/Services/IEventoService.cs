using DeslandesApp.Domain.Models.Dtos.Requests.Evento;
using DeslandesApp.Domain.Models.Dtos.Responses.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.Evento;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IEventoService : IBaseService<CriarEventoRequest, UpdateEventoRequest, CriarEventoResponse, Guid>
    {
        Task AtualizarStatusAutomatico();
        Task<PageResult<EventoPaginacaoResponse>> ConsultarEventoPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null);

    }
}