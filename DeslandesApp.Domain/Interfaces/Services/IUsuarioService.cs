using DeslandesApp.Domain.Models.Dtos.Requests.Usuario;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<UsuarioRequest, UsuarioResponse, Guid>
    {
    }
}
