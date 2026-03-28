using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IGrupoClientesProcessoRepository : IBaseRepository<GrupoPessoaClientes, Guid>
    {
        Task<GrupoPessoaClientes> GetByIdCliente(Guid idCliente, Guid idProcesso, Guid IdQualificacao);
        Task<GrupoPessoaClientes> ExistClienteProcessoAsync(Guid idCliene, Guid idProcesso, Guid IdQualificacao);
    }
}
