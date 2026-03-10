using DeslandesApp.Domain.Models.Dtos.Requests.Endereco;
using DeslandesApp.Domain.Models.Dtos.Requests.Setor;
using DeslandesApp.Domain.Models.Dtos.Responses.Endereco;
using DeslandesApp.Domain.Models.Dtos.Responses.Setor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IEnderecoService : IBaseService<EnderecoRequest, EnderecoUpdateRequest,EnderecoResponse, Guid>
    {
    }
}
