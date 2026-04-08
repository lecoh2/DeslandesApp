using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Infra.Data.Contexts;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class GrupoPessoasEtiquetasRepository(DataContext dataContext)
        : BaseRepository<GrupoPessoasEtiquetas, Guid>(dataContext), IGrupoPessoasEtiquetasRepository
    {
        public async Task<GrupoPessoasEtiquetas?> ExistPessoasEtiquetaAsync(Guid idEtiqueta, Guid idPessoa)
        {
            return await dataContext.GrupoPessoasEtiquetas
                .FirstOrDefaultAsync(gc => gc.EtiquetaId == idEtiqueta && gc.PessoaId == idPessoa);
        }

        public async Task<GrupoPessoasEtiquetas?> GetByIdPessoasEtiquetasAsync(Guid idEtiqueta, Guid idPessoa)
        {
            return await dataContext.GrupoPessoasEtiquetas
                .FirstOrDefaultAsync(gc => gc.EtiquetaId == idEtiqueta && gc.PessoaId == idPessoa);
        }
    }
}