using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class HistoricoGeralRepository(DataContext dataContext)
         : BaseRepository<HistoricoGeral, Guid>(dataContext), IHistoricoGeralRepository
    {
        public async Task<List<HistoricoGeral>> ObterPorEntidadeAsync(TipoEntidade entidade, Guid entidadeId)
        {
            return await dataContext.Set<HistoricoGeral>()
    .Include(x => x.Usuario) 
    .Where(x => x.Entidade == entidade && x.EntidadeId == entidadeId)
    .OrderByDescending(x => x.DataAlteracao)
    .ToListAsync();
        }
    }
}
