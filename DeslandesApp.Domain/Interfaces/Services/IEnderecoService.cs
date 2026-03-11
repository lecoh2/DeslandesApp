
using DeslandesApp.Domain.Models.Dtos.Requests.EnderecoPessoa;
using DeslandesApp.Domain.Models.Dtos.Requests.Setor;
using DeslandesApp.Domain.Models.Dtos.Responses.EnderecoEndereco;
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
