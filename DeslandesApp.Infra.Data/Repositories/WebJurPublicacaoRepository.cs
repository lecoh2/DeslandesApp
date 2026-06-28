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
    public class WebJurPublicacaoRepository(DataContext dataContext)
       : BaseRepository<WebJurPublicacao, Guid>(dataContext),
         IWebJurPublicacaoRepository
    {
      

        public async Task<bool> ExistePorCodigoAsync(
            int codPublicacao)
        {
            return await dataContext.WebJurPublicacoes
                .AnyAsync(x =>
                    x.CodPublicacao == codPublicacao);
        }

        public async Task<List<WebJurPublicacao>>
            ObterNaoImportadasAsync()
        {
            return await dataContext.WebJurPublicacoes
                .Where(x => !x.Importada)
                .OrderBy(x => x.DataPublicacao)
                .ToListAsync();
        }
        public async Task<bool> ExisteAsync(string numeroProcesso, DateTime dataPublicacao)
        {
            return await dataContext.WebJurPublicacoes
                .AnyAsync(x => x.NumeroProcesso == numeroProcesso
                            && x.DataPublicacao == dataPublicacao);
        }
        public async Task<List<int>> ObterCodigosExistentesAsync(List<int> codigos)
        {
            return await dataContext.WebJurPublicacoes
                .Where(x => codigos.Contains(x.CodPublicacao))
                .Select(x => x.CodPublicacao)
                .ToListAsync();
        }
        public async Task<PageResult<WebJurPublicacaoResponse>> GetPaginacaoAsync(
    int pageNumber,
    int pageSize,
    string? searchTerm = null)
        {
            var query = dataContext.WebJurPublicacoes
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.ToLower();

                query = query.Where(x =>
                    x.NumeroProcesso.ToLower().Contains(term) ||
                    x.DespachoPublicacao.ToLower().Contains(term)
                );
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.DataPublicacao)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new WebJurPublicacaoResponse
                {
                    Id = x.Id,
                    CodPublicacao = x.CodPublicacao,
                    NumeroProcesso = x.NumeroProcesso,
                    DataPublicacao = x.DataPublicacao,
                    DespachoPublicacao = x.DespachoPublicacao
                })
                .ToListAsync();

            return new PageResult<WebJurPublicacaoResponse>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public async Task<WebJurPublicacao?> ObterCompletoAsync(Guid id)
        {
            return await dataContext.WebJurPublicacoes
                .Include(x => x.Processo)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<WebJurPublicacao?> ObterDetalheAsync(Guid id)
        {
            return await dataContext.WebJurPublicacoes
                .AsNoTracking()

                .Include(x => x.Processo)

                .Include(x => x.Comentarios)
                    .ThenInclude(x => x.Usuario)

                .Include(x => x.Movimentacoes)

                .Include(x => x.Arquivos)

                .Include(x => x.Visualizacoes)
                    .ThenInclude(x => x.Usuario)

                .Include(x => x.Sincronizacoes)
                    .ThenInclude(x => x.Usuario)

                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
