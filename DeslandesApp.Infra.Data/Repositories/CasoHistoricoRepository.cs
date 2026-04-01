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
    public class CasoHistoricoRepository(DataContext dataContext)
        : BaseRepository<CasoHistorico, Guid>(dataContext), ICasoHistoricoRepository
    {
        public async Task<List<CasoHistorico>> ConsultarCasoHistoricoComRelacionamentosAsync(Guid id)
        {
            return await dataContext.CasoHistorico
            .Include(h => h.Usuario)
        .ThenInclude(u => u.Pessoa)
    .Where(h => h.CasoId == id)
    .OrderByDescending(h => h.DataAlteracao)
    .ToListAsync();
        }
    }
}
