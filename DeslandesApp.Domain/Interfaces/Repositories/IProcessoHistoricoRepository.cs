using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IProcessoHistoricoRepository : IBaseRepository<ProcessoHistorico, Guid>
    {
         Task<List<ProcessoHistorico>> ConsultarProcessoHistoricoComRelacionamentosAsync(Guid id);
    }
}
