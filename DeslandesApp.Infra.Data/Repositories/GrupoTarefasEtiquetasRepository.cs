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
    public class GrupoTarefasEtiquetasRepository(DataContext dataContext)
        : BaseRepository<GrupoTarefasEtiquetas, Guid>(dataContext), IGrupoTarefasEtiquetasRepository
    {
        public async Task RemoverPorTarefaId(Guid tarefaId)
        {
            var registros = await dataContext.GrupoTarefasEtiquetas
                .Where(x => x.TarefaId == tarefaId)
                .ToListAsync();

            dataContext.GrupoTarefasEtiquetas.RemoveRange(registros);
        }
    }
}


