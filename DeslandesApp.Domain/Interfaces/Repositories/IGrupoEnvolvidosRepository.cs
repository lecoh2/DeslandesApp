using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IGrupoEnvolvidosRepository : IBaseRepository<GrupoEnvolvidos, Guid>
    {
        Task<GrupoEnvolvidos> GetByIdEnvolvido(Guid idCliente, Guid idProcesso, Guid IdQualificacao);
        Task<GrupoEnvolvidos> ExistEnvolvidoProcessoAsync(Guid idCliene, Guid idProcesso, Guid IdQualificacao);
    }
}