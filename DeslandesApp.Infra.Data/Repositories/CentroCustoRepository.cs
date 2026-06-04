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
    public class CentroCustoRepository(DataContext dataContext)
        : BaseRepository<CentroCusto, Guid>(dataContext),
          ICentroCustoRepository
    {
        public async Task<CentroCusto?> ObterCompletoPorIdAsync(Guid id)
        {
            return await dataContext.CentroCusto
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
