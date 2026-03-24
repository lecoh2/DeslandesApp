using DeslandesApp.Domain.Models.Dtos.Requests.Evento;
using DeslandesApp.Domain.Models.Dtos.Responses.Evento;
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
    }
}