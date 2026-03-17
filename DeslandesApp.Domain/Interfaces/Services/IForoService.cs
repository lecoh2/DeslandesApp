
using DeslandesApp.Domain.Models.Dtos.Requests.Foro;
using DeslandesApp.Domain.Models.Dtos.Responses.Foro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IForoService : IBaseService<ForoRequest, ForoUpdateRequest, ForoResponse, Guid>
    { }
}