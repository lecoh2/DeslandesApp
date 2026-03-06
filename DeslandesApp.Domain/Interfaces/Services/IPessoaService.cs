using DeslandesApp.Domain.Models.Dtos.Requests.Pessoa;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IPessoaService : IBaseService<PessoaRequest, PessoaResponse, Guid>
    {
    }
}
