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
    public class GrupoTarefaResponsaveisRepository(DataContext dataContext)
        : BaseRepository<GrupoTarefaResponsaveis, Guid>(dataContext), IGrupoTarefaResponsaveisRepository
    {
        public async Task<GrupoTarefaResponsaveis> ExistTarefaResponsaveisAsync(Guid idUsuario, Guid idTarefa)
        {
            return await dataContext.GrupoTarefaResponsaveis
                .FirstOrDefaultAsync(gr => gr.UsuarioId == idUsuario && gr.TarefaId == idTarefa);
        }
        

        public async Task<GrupoTarefaResponsaveis> GetByIdTarefaResponsaveisAsync(Guid idUsuario, Guid idTarefa)
        {
            return await dataContext.GrupoTarefaResponsaveis

        .Where(gc => gc.UsuarioId == idUsuario && gc.TarefaId == idTarefa )
        .FirstOrDefaultAsync();
        }
        public async Task RemoverPorTarefaId(Guid tarefaId)
        {
            var registros = await dataContext.GrupoTarefaResponsaveis
                .Where(x => x.TarefaId == tarefaId)
                .ToListAsync();

            dataContext.GrupoTarefaResponsaveis.RemoveRange(registros);
        }
    }
}
