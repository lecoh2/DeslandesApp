using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface ICentroCustoRepository
          : IBaseRepository<CentroCusto, Guid>
    {
        Task<CentroCusto?> ObterCompletoPorIdAsync(Guid id);
    }
}
