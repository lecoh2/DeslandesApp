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
    public class WebJurVisualizacaoRepository(DataContext dataContext) : IWebJurVisualizacaoRepository
    {
        public async Task AdicionarAsync(WebJurVisualizacao visualizacao)
        {
            await dataContext.WebJurVisualizacao.AddAsync(visualizacao);
        }

        public async Task<List<WebJurVisualizacao>> ObterPorPublicacaoAsync(Guid publicacaoId)
        {
            return await dataContext.WebJurVisualizacao
                .Include(x => x.Usuario)
                .Where(x => x.WebJurPublicacaoId == publicacaoId)
                .OrderByDescending(x => x.DataVisualizacao)
                .ToListAsync();
        }
    }
}
