using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoa;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoa;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class PessoaService(IUnitOfWork unitOfWork, IMapper mapper) : IPessoaService
    {
        public Task<PessoaResponse> AdicionarAsync(PessoaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<PessoaResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<PessoaResponse> Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PessoaResponse> Modificar(Guid id, PessoaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PessoaResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
