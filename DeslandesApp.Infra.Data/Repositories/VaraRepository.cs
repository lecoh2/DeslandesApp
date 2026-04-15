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
    public class VaraRepository(DataContext dataContext) : BaseRepository<Vara, Guid>(dataContext), IVaraRepository
    {
        public async Task<List<Vara>> GetAllWithForoAsync()
        {
            return await dataContext.Varas
                .Include(v => v.Foro)
                .ToListAsync();
        }
    }
}
