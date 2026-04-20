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
        public Task<EtiquetaResponse> AdicionarAsync(EtiquetasRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EtiquetaResponse>> ConsultarAsync()
        {
            var etiquetas = await unitOfWork.EtiquetaRepository.GetAllAsync();

            return mapper.Map<IEnumerable<EtiquetaResponse>>(etiquetas);
        }

        public Task<PageResult<EtiquetaResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<EtiquetaResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<EtiquetaResponse> ModificarAsync(Guid id, EtiquetasUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<EtiquetaResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
