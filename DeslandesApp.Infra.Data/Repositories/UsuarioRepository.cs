using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
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
