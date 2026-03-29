using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IGrupoEtiquetasProcessosRepository : IBaseRepository<GrupoEtiquetasProcessos, Guid>
    {
        Task<GrupoEtiquetasProcessos> GetByIdEtiquetaProcessoAsync(Guid idEtiqueta, Guid idProcesso);
        Task<GrupoEtiquetasProcessos> ExistEtiquetaProcessoAsync(Guid idEtiqueta, Guid idProcesso);
    }
}
