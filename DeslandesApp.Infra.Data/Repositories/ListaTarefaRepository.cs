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
    public class ListaTarefaRepository(DataContext dataContext) : BaseRepository<ListaTarefa, Guid>(dataContext), IListaTarefaRepository
    {
        public async Task<int?> ObterMaiorOrdemPorTarefaId(Guid tarefaId)
        {
            return await dataContext.ListasTarefa
                .Where(x => x.TarefaId == tarefaId)
                .MaxAsync(x => (int?)x.Ordem);
        }
        public async Task<List<ListaTarefa>> ObterPorIdsAsync(List<Guid> ids)
        {
            return await dataContext.ListasTarefa
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }
    }
}
