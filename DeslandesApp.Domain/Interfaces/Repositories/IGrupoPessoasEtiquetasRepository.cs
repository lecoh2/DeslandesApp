using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IGrupoPessoasEtiquetasRepository : IBaseRepository<GrupoPessoasEtiquetas, Guid>
    {
        Task<GrupoPessoasEtiquetas?> GetByIdPessoasEtiquetasAsync(Guid idEtiqueta, Guid idPessoa);
        Task<GrupoPessoasEtiquetas?> ExistPessoasEtiquetaAsync(Guid idEtiqueta, Guid idPessoa);
    }
}
