using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IGrupoTarefaResponsaveisRepository : IBaseRepository<GrupoTarefaResponsaveis, Guid>
    {
        Task<GrupoTarefaResponsaveis> GetByIdTarefaResponsaveisAsync(Guid idPessoa, Guid idTarefa);
        Task<GrupoTarefaResponsaveis> ExistTarefaResponsaveisAsync(Guid idPessoa, Guid idTarefa);
    }
}
