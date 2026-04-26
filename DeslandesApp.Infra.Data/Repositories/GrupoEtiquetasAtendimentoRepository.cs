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
    public class GrupoEtiquetasAtendimentoRepository(DataContext dataContext)
        : BaseRepository<GrupoEtiquetasAtendimentos, Guid>(dataContext), IGrupoEtiquetasAtendimentoRepository
    {
        public async Task<GrupoEtiquetasAtendimentos> ExistEtiquetaAtendimentoAsync(Guid idEtiqueta, Guid idAtendimento)
        {
            return await dataContext.GrupoEtiquetasAtendimentos
                .FirstOrDefaultAsync(gr => gr.EtiquetaId == idEtiqueta&& gr.AtendimentoId == idAtendimento);
        }

        public async Task<GrupoEtiquetasAtendimentos> GetByIdEtiquetaAtendimentoAsync(Guid idEtiqueta, Guid idAtendimento)
        {
            return await dataContext.GrupoEtiquetasAtendimentos

        .Where(gr => gr.EtiquetaId == idEtiqueta && gr.AtendimentoId == idAtendimento)
        .FirstOrDefaultAsync();
        }

        public async Task RemoverPorAtendimentoId(Guid atendimentoId)
        {
            var registros = await dataContext.GrupoEtiquetasAtendimentos
                .Where(x => x.AtendimentoId == atendimentoId)
                .ToListAsync();

            dataContext.GrupoEtiquetasAtendimentos.RemoveRange(registros);
        }
    }
}