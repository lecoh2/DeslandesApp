using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IGrupoEtiquetasAtendimentoRepository : IBaseRepository<GrupoEtiquetasAtendimentos, Guid>
    {
        Task<GrupoEtiquetasAtendimentos> GetByIdEtiquetaAtendimentoAsync(Guid idEtiqueta, Guid idAtendiemnto);
        Task<GrupoEtiquetasAtendimentos> ExistEtiquetaAtendimentoAsync(Guid idEtiqueta, Guid idAtendiemnto);
    }
}
