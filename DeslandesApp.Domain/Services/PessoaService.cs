using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
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
        public Task<PessoaFisicaResponse> AdicionarAsync(PessoaFisicaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<PessoaFisicaResponse>> ConsultarAsync(int pageNumber, int pageSize , string? serchTerms = null)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<PessoaFisicaResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<PessoaFisicaResponse>> ConsultarPaginacaoAsync(int pageNumber, int pageSize, string? serchTerm = null)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<PessoaFisicaResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PessoaFisicaResponse> ModificarAsync(Guid id, PessoaFisicaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PessoaFisicaResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
