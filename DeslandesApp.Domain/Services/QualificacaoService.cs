using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Qualificacao;
using DeslandesApp.Domain.Models.Dtos.Responses.Qualificacao;
using DeslandesApp.Domain.Models.Dtos.Responses.Vara;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class QualificacaoService(IUnitOfWork unitOfWork, IMapper mapper) : IQualidicacaoService
    {
        public Task<QualificacaoResponse> AdicionarAsync(QualificacaoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<QualificacaoResponse>> ConsultarAsync()
        {
            var acao = await unitOfWork.QualificacaoRepository.GetAllAsync();

            var response = mapper.Map<List<QualificacaoResponse>>(acao);

            return response;
        }

        public Task<PageResult<QualificacaoResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<QualificacaoResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<QualificacaoResponse> ModificarAsync(Guid id, QualificacaoUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<QualificacaoResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
