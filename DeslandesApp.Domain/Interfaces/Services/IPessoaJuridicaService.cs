using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IPessoaJuridicaService : IBaseService<PessoaJuridicaRequest, PessoaJuridicaUpdateRequest, PessoaJuridicaResponse, Guid>
    {
        Task<PageResult<PessoaJuridicaPaginacaoResponse>> ConsultarPessoaJuridicaPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null);
    }
}
