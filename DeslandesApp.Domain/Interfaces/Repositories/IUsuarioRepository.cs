using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, Guid>
    {
        Task<Usuario?> GetUsuarioByLoginAsync(string login);
        Task<PageResult<UsuariosResponse>>
        GetAllPaginacao(
            int pageNumber,
            int pageSize,
            string? searchTerm = null);
    }
}
