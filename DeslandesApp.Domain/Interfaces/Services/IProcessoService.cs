
using DeslandesApp.Domain.Models.Dtos.Requests.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IProcessoService : IBaseService<ProcessoRequest, ProcessoUpdateRequest, ProcessoResponse, Guid>
    {

    }
}