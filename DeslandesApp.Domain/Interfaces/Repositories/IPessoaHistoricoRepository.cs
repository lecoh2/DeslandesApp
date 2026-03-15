using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IPessoaHistoricoRepository : IBaseRepository<PessoaHistorico, Guid>
    {
        Task<List<PessoaHistorico>> ConsultarPessoaFisicaHistoricoComRelacionamentosAsync(Guid id);
        Task<List<PessoaHistorico>> ConsultarPessoaJuridicaHistoricoComRelacionamentosAsync(Guid id);
    }
}
