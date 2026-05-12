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
    public class SetorRepository (DataContext dataContext)
        : BaseRepository<Setor, Guid>(dataContext), ISetorRepository
    {
        public async Task<List<Setor>> GetSetoresPorNomeAsync(string nomeSetor)
        {

            var query = dataContext.Setor
                .OfType<Setor>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(nomeSetor))
            {
                query = query.Where(p => p.NomeSetor.Contains(nomeSetor));
            }

            return await query.ToListAsync();
        }
    }
}
