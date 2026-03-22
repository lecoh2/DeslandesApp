using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Evento;
using DeslandesApp.Domain.Models.Dtos.Responses.Evento;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class EventoService(IUnitOfWork unitOfWork, IMapper mapper) : IEventoService
    {
        public Task<CriarEventoResponse> AdicionarAsync(CriarEventoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<CriarEventoResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<CriarEventoResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CriarEventoResponse> ModificarAsync(Guid id, UpdateEventoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CriarEventoResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
