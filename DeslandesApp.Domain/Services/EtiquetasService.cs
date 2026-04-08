using AutoMapper;
using DeslandesApp.Domain.Contracts.Security;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Etiquetas;
using DeslandesApp.Domain.Models.Dtos.Responses.Etiquetas;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class EtiquetasService(IUnitOfWork unitOfWork, IMapper mapper) : IEtiquetasService
    {
        public Task<EtiquetasResponse> AdicionarAsync(EtiquetasRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EtiquetasResponse>> ConsultarAsync()
        {
            var etiquetas = await unitOfWork.EtiquetaRepository.GetAllAsync();

            return mapper.Map<IEnumerable<EtiquetasResponse>>(etiquetas);
        }

        public Task<PageResult<EtiquetasResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<EtiquetasResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<EtiquetasResponse> ModificarAsync(Guid id, EtiquetasUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<EtiquetasResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
