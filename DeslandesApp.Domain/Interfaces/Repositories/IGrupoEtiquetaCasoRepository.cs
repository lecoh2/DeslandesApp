using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IGrupoEtiquetaCasoRepository : IBaseRepository<GrupoEtiquetaCasos, Guid>
    {
        Task<GrupoEtiquetaCasos> GetByIdEtiquetaCasoAsync(Guid idEtiqueta, Guid idAtendiemnto);
        Task<GrupoEtiquetaCasos> ExistEtiquetaCasoAsync(Guid idEtiqueta, Guid idAtendiemnto);
    }
}
