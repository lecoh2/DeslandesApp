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
    public class GrupoCasoEnvolvidosRepository(DataContext dataContext)
        : BaseRepository<GrupoCasoEnvolvido, Guid>(dataContext), IGrupoCasoEnvolvidosRepository
    {
        public async Task<GrupoCasoEnvolvido> ExistCasoEnvolvidoAsync(Guid idPessoa, Guid idCaso)
        {
            return await dataContext.GrupoCasoEnvolvido
                .FirstOrDefaultAsync(gr => gr.PessoaId == idPessoa && gr.CasoId == idCaso);
        }

        public async Task<GrupoCasoEnvolvido> GetByIdEnvolvidoAsync(Guid idPessoa, Guid idCaso)
        {
            return await dataContext.GrupoCasoEnvolvido

        .Where(gr => gr.PessoaId == idPessoa && gr.CasoId == idPessoa)
        .FirstOrDefaultAsync();
        }
    }
}