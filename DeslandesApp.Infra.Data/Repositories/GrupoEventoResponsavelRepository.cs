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
    public class GrupoEventoResponsavelRepository(DataContext dataContext)
        : BaseRepository<GrupoEventoResponsavel, Guid>(dataContext), IGrupoEventoResponsavelRepository
    {
        public async Task<GrupoEventoResponsavel> ExistEventoResponsaveisAsync(Guid idEvento, Guid idUsuario)
        {
            return await dataContext.GrupoEventoResponsavel
               .FirstOrDefaultAsync(gc => gc.EventoId == idEvento && gc.UsuarioId == idUsuario);
        }

        public async Task<GrupoEventoResponsavel> GetByIdEventoResponsaveisAsync(Guid idEvento, Guid idUsuario)
        {
            return await dataContext.GrupoEventoResponsavel

        .Where(gc => gc.EventoId == idEvento && gc.UsuarioId == idUsuario)
        .FirstOrDefaultAsync();
        }
    }
}
