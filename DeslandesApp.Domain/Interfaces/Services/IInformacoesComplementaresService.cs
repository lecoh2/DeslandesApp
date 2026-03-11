using DeslandesApp.Domain.Models.Dtos.Requests.EnderecoPessoa;
using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;
using DeslandesApp.Domain.Models.Dtos.Responses.EnderecoEndereco;
using DeslandesApp.Domain.Models.Dtos.Responses.InformacoesComplementares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IInformacoesComplementaresService : IBaseService<InformacoesComplementaresRequest, InformacoesComplementaresUpdateRequest, InformacoesComplementaresResponse, Guid>
    {
    }
}
