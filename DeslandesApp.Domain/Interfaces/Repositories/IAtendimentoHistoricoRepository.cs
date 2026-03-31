using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IAtendimentoHistoricoRepository : IBaseRepository<AtendimentoHistorico, Guid>
    {
        Task<List<AtendimentoHistorico>> ConsultarAtendimentoHistoricoComRelacionamentosAsync(Guid id);
    }
}
