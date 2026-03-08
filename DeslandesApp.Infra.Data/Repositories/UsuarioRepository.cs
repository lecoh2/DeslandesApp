using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class UsuarioRepository(DataContext dataContext)
        : BaseRepository<Usuario, Guid>(dataContext), IUsuarioRepository
    {
        public Task<PageResult<UsuariosResponse>> GetAllPaginacao(int pageNumber, int pageSize, string? searchTerm = null)
        {
            throw new NotImplementedException();
        }

        // Buscar usuário apenas pelo login
        public async Task<Usuario?> GetUsuarioByLoginAsync(string login)
        {
            return await dataContext.Set<Usuario>()
                .Include(u => u.Pessoa)
                    .ThenInclude(p => p.Sexo)
                .Include(u => u.GrupoNiveis)
                    .ThenInclude(gn => gn.Niveis)
                .FirstOrDefaultAsync(u => u.Login == login);
        }
    }
}
