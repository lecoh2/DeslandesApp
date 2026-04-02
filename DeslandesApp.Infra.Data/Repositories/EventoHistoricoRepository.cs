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
    public class EventoHistoricoRepository(DataContext dataContext)
        : BaseRepository<EventoHistorico, Guid>(dataContext), IEventoHistoricoRepository
    {
        public async Task<List<EventoHistorico>> ConsultarEventoHistoricoComRelacionamentosAsync(Guid id)
        {
            return await dataContext.EventoHistorico
    .Include(h => h.Usuario)
    .Where(h => h.EventoId == id)
    .OrderByDescending(h => h.DataAlteracao)
    .ToListAsync();
        }
    }
}
