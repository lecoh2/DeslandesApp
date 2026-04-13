using DeslandesApp.Domain.Models.Dtos.Requests.Vara;
using DeslandesApp.Domain.Models.Dtos.Responses.Vara;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IAcaoService : IBaseService<AcaoRequest, AcaoUpdateRequest, AcaoResponse, Guid>
    { Task<List<AcaoResponse>> ConsultarAsync(); }
}

