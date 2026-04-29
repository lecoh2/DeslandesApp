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
    public class GrupoEtiquetasCasosRepository(DataContext dataContext)
        : BaseRepository<GrupoEtiquetaCasos, Guid>(dataContext), IGrupoEtiquetaCasoRepository
    {
        public async Task<GrupoEtiquetaCasos> ExistEtiquetaCasoAsync(Guid idEtiqueta, Guid idCaso)
        {
            return await dataContext.GrupoEtiquetaCasos
                .FirstOrDefaultAsync(gr => gr.EtiquetaId == idEtiqueta && gr.CasoId == idCaso);
        }

        public async Task<GrupoEtiquetaCasos> GetByIdEtiquetaCasoAsync(Guid idEtiqueta, Guid idCaso)
        {
            return await dataContext.GrupoEtiquetaCasos

        .Where(gr => gr.EtiquetaId == idEtiqueta && gr.CasoId == idCaso)
        .FirstOrDefaultAsync();
        }

        public async Task RemoverPorCasoId(Guid casoId)
        {
            var registros = await dataContext.GrupoEtiquetaCasos
                .Where(x => x.CasoId == casoId)
                .ToListAsync();

            dataContext.GrupoEtiquetaCasos.RemoveRange(registros);
        }
    }
}

