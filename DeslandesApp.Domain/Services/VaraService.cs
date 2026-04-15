using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Vara;
using DeslandesApp.Domain.Models.Dtos.Responses.Vara;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class VaraService(IUnitOfWork unitOfWork, IMapper mapper) : IVaraService
    {
        public Task<VaraResponse> AdicionarAsync(VaraRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VaraResponse>> ConsultarAsync()
        {
            var varas = await unitOfWork.VaraRepository.GetAllWithForoAsync();

            return mapper.Map<List<VaraResponse>>(varas);
        }

        public Task<PageResult<VaraResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<VaraResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

      

        public Task<VaraResponse> ModificarAsync(Guid id, VaraUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<VaraResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
