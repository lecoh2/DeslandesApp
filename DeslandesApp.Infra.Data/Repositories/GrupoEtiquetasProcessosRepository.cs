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
    public class GrupoEtiquetasProcessosRepository(DataContext dataContext)
        : BaseRepository<GrupoEtiquetasProcessos, Guid>(dataContext), IGrupoEtiquetasProcessosRepository
    {
        public async Task<GrupoEtiquetasProcessos> ExistEtiquetaProcessoAsync(Guid idEtiqueta, Guid idProcesso)
        {
            return await dataContext.GrupoEtiquetasProcessos
                .FirstOrDefaultAsync(gr => gr.EtiquetaId == idEtiqueta && gr.ProcessoId == idProcesso);
        }

        public async Task<GrupoEtiquetasProcessos> GetByIdEtiquetaProcessoAsync(Guid idEtiqueta, Guid idProcesso)
        {
            return await dataContext.GrupoEtiquetasProcessos

        .Where(gr => gr.EtiquetaId == idEtiqueta && gr.ProcessoId == idProcesso)
        .FirstOrDefaultAsync();
        }

        public async Task RemoverEtiquetaProcessoPorId(Guid tarefaId)
        {
            var registros = await dataContext.GrupoEtiquetasProcessos
                .Where(x => x.ProcessoId == tarefaId)
                .ToListAsync();

            dataContext.GrupoEtiquetasProcessos.RemoveRange(registros);
        }
    }
}