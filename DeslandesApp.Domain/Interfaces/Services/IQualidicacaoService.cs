
using DeslandesApp.Domain.Models.Dtos.Requests.Qualificacao;
using DeslandesApp.Domain.Models.Dtos.Responses.Qualificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IQualidicacaoService : IBaseService<QualificacaoRequest, QualificacaoUpdateRequest, QualificacaoResponse, Guid>
    {

    }
}
