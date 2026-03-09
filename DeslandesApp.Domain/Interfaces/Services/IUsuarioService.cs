
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<UsuariosRequest, UsuarioUpdateRequest, UsuariosResponse,   Guid>
    {
        Task<AutenticarUsuarioResponse> AutenticarUsuarioAsync(
 AutenticarUsuarioRequest request,
 string ip,
 string userAgent);
        Task<PageResult<UsuarioPaginacaoResponse>> ConsultarUsuariosComPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null);

    }
}
