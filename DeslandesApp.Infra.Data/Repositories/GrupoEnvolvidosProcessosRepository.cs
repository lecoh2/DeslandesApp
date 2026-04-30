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
    public class GrupoEnvolvidosProcessosRepository(DataContext dataContext)
        : BaseRepository<GrupoEnvolvidosProcesso, Guid>(dataContext), IGrupoEnvolvidosProcessoRepository
    {
        public async Task<GrupoEnvolvidosProcesso> ExistEnvolvidosProcessoAsync(Guid idPessoa, Guid idProcesso)
        {
            return await dataContext.GrupoEnvolvidosProcesso
                .FirstOrDefaultAsync(gr => gr.PessoaId == idPessoa && gr.ProcessoId == idProcesso);
        }

        public async Task<GrupoEnvolvidosProcesso> GetByIdEnvolvidosProcessoAsync(Guid idPessoa, Guid idProcesso)
        {
            return await dataContext.GrupoEnvolvidosProcesso

        .Where(gr => gr.PessoaId == idPessoa && gr.ProcessoId == idProcesso)
        .FirstOrDefaultAsync();
        }

        public async Task RemoverEnvolvidosProcessoPorId(Guid tarefaId)
        {
            var registros = await dataContext.GrupoEnvolvidosProcesso
                .Where(x => x.ProcessoId == tarefaId)
                .ToListAsync();

            dataContext.GrupoEnvolvidosProcesso.RemoveRange(registros);
        }
    }
}