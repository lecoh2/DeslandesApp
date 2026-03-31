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
    public class AtendimentoHistoricoRepository(DataContext dataContext)
        : BaseRepository<AtendimentoHistorico, Guid>(dataContext), IAtendimentoHistoricoRepository
    {
        public async Task<List<AtendimentoHistorico>> ConsultarAtendimentoHistoricoComRelacionamentosAsync(Guid id)
        {
            return await dataContext.AtendimentoHistorico
    .Include(h => h.Usuario)
        .ThenInclude(u => u.Pessoa)
    .Where(h => h.AtendimentoId == id)
    .OrderByDescending(h => h.DataAlteracao)
    .ToListAsync();
        }
    }
}
