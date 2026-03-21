using DeslandesApp.Domain.Models.Dtos.Requests.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.Atendimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IAtendimentoService : IBaseService<CriarAtendimentoClienteRequest, AtendimentoClienteUpdateRequest, CriarAtendimentoClienteResponse, Guid>
    {
    }
}