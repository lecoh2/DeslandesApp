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
    public class NivelRepository(DataContext dataContext)
        : BaseRepository<Niveis, Guid>(dataContext), INivelRepository
    {
        public async Task<List<Niveis>> GetNivelPorNomeAsync(string nomeNivel)
        {

            var query = dataContext.Niveis
                .OfType<Niveis>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(nomeNivel))
            {
                query = query.Where(p => p.NomeNivel.Contains(nomeNivel));
            }

            return await query.ToListAsync();
        }
    }
}
