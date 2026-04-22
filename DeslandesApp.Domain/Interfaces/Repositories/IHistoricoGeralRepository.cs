using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IHistoricoGeralRepository : IBaseRepository<HistoricoGeral, Guid>
    {
        Task<List<HistoricoGeral>> ObterPorEntidadeAsync(TipoEntidade entidade, Guid entidadeId);
    }
}
