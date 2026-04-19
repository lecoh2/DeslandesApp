using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IGrupoEventoEtiquetasRepository : IBaseRepository<GrupoEventoEtiquetas, Guid>
    {
        Task<GrupoEventoEtiquetas> GetByIdEventoEtiquetasAsync(Guid idEtiqueta, Guid idEvento);
        Task<GrupoEventoEtiquetas> ExistEventoEtiquetasAsync(Guid idEtiqueta, Guid idEvento);
    }
}
