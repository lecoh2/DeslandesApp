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
    public class GrupoEventoEtiquetasRepository(DataContext dataContext)
        : BaseRepository<GrupoEventoEtiquetas, Guid>(dataContext), IGrupoEventoEtiquetasRepository
    {

        public async Task<GrupoEventoEtiquetas> ExistEventoEtiquetasAsync(Guid idEtiqueta, Guid idEvento)
        {
            return await dataContext.GrupoEventoEtiquetas
                .FirstOrDefaultAsync(gr => gr.EtiquetaId == idEtiqueta && gr.EventoId == idEvento);
        }

        public async Task<GrupoEventoEtiquetas> GetByIdEventoEtiquetasAsync(Guid idEtiqueta, Guid idEvento)
        {
            return await dataContext.GrupoEventoEtiquetas

        .Where(gr => gr.EtiquetaId == idEtiqueta && gr.EventoId == idEvento)
        .FirstOrDefaultAsync();
        }
    }
}


