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
        public async Task<GrupoTarefaResponsaveis> ExistTarefaResponsaveisAsync(Guid idPessoa, Guid idTarefa)
        {
            return await dataContext.GrupoTarefaResponsaveis
                .FirstOrDefaultAsync(gr => gr.PessoaId == idPessoa && gr.TarefaId == idTarefa);
        }
        

        public async Task<GrupoTarefaResponsaveis> GetByIdTarefaResponsaveisAsync(Guid idPessoa, Guid idTarefa)
        {
            return await dataContext.GrupoTarefaResponsaveis

        .Where(gc => gc.PessoaId == idPessoa && gc.TarefaId == idTarefa )
        .FirstOrDefaultAsync();
        }
    }
}
