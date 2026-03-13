using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IPessoaJuridicaService : IBaseService<PessoaJuridicaRequest, PessoaJuridicaUpdateRequest, PessoaJuridicaResponse, Guid>
    {
    }
}
