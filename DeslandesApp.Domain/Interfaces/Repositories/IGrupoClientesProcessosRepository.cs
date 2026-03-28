using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IGrupoClientesProcessosRepository : IBaseRepository<GrupoClienteProcesso, Guid>
    {
        Task<GrupoClienteProcesso> GetByIdClienteProcessoAsync(Guid idCliente, Guid idProcesso);
        Task<GrupoClienteProcesso> ExistClienteProcessoAsync(Guid idClietne, Guid idProcesso);
    }
}