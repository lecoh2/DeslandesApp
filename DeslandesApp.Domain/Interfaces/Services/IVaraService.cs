using DeslandesApp.Domain.Models.Dtos.Requests.Foro;
using DeslandesApp.Domain.Models.Dtos.Requests.Vara;
using DeslandesApp.Domain.Models.Dtos.Responses.Foro;
using DeslandesApp.Domain.Models.Dtos.Responses.Vara;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IVaraService : IBaseService<VaraRequest, VaraUpdateRequest, VaraResponse, Guid>
    { Task<List<VaraResponse>> ConsultarAsync(); }
}

