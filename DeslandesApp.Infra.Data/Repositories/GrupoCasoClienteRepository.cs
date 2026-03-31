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
    public class GrupoCasoClienteRepository(DataContext dataContext)
        : BaseRepository<GrupoCasoCliente, Guid>(dataContext), IGrupoCasoClienteRepository
    {
        public async Task<GrupoCasoCliente> ExistCasoClienteAsync(Guid idPessoa, Guid idCaso)
        {
            return await dataContext.GrupoCasoCliente
                .FirstOrDefaultAsync(gr => gr.PessoaId == idPessoa && gr.CasoId == idCaso);
        }

        public async Task<GrupoCasoCliente> GetByIdClienteAsync(Guid idPessoa, Guid idCaso)
        {
            return await dataContext.GrupoCasoCliente

        .Where(gr => gr.PessoaId == idPessoa && gr.CasoId == idPessoa)
        .FirstOrDefaultAsync();
        }
    }
}