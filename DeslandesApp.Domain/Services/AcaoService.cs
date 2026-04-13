using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Vara;
using DeslandesApp.Domain.Models.Dtos.Responses.Vara;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class AcaoService(IUnitOfWork unitOfWork, IMapper mapper) : IAcaoService
    {
        public Task<AcaoResponse> AdicionarAsync(AcaoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AcaoResponse>> ConsultarAsync()
        {
            var acao = await unitOfWork.AcaoRepository.GetAllAsync();

            var response = mapper.Map<List<AcaoResponse>>(acao);

            return response;
        }

        public Task<PageResult<AcaoResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<AcaoResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AcaoResponse> ModificarAsync(Guid id, AcaoUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AcaoResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
