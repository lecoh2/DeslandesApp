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
    public class GrupoClientesProcessoRepository(DataContext dataContext)
        : BaseRepository<GrupoClienteProcesso, Guid>(dataContext), IGrupoClientesProcessosRepository
    {
        public async Task<GrupoClienteProcesso> ExistClienteProcessoAsync(Guid idPessoa, Guid idProcesso)
        {
            return await dataContext.GrupoClienteProcesso
                .FirstOrDefaultAsync(gr => gr.PessoaId == idPessoa && gr.ProcessoId == idProcesso);
        }

        public async Task<GrupoClienteProcesso> GetByIdClienteProcessoAsync(Guid idPessoa, Guid idProcesso)
        {
            return await dataContext.GrupoClienteProcesso

        .Where(gr => gr.PessoaId == idPessoa && gr.ProcessoId == idProcesso)
        .FirstOrDefaultAsync();
        }

       
    }
}
