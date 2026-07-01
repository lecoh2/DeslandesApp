using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Responses.WebJur;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Infra.Data.Contexts;
using DocumentFormat.OpenXml.InkML;
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
        public async Task<PageResult<WebJurVisualizacaoResponse>> GetPaginacaoAsync(
            Guid publicacaoId,
            int pageNumber,
            int pageSize)
        {
            var query = dataContext.WebJurVisualizacao
                .AsNoTracking()
                .Where(x => x.WebJurPublicacaoId == publicacaoId);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.DataVisualizacao)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new WebJurVisualizacaoResponse
                {
                    Id = x.Id,
                    Usuario = x.Usuario.NomeUsuario,
                    DataVisualizacao = x.DataVisualizacao
                })
                .ToListAsync();

            return new PageResult<WebJurVisualizacaoResponse>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
