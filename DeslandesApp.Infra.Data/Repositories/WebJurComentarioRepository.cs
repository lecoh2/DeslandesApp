using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
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
    public class WebJurComentarioRepository(DataContext dataContext)
         : IWebJurComentarioRepository
    {
       

        public async Task AdicionarAsync(WebJurComentario comentario)
        {
            await dataContext.WebJurComentario.AddAsync(comentario);
        }

        public async Task<List<WebJurComentario>> ObterPorPublicacaoAsync(Guid publicacaoId)
        {
            return await dataContext.WebJurComentario
                .Include(x => x.Usuario)
                .Where(x => x.WebJurPublicacaoId == publicacaoId)
                .OrderByDescending(x => x.DataCadastro)
                .ToListAsync();
        }
        public async Task<List<WebJurComentario>> ObterPaginadoAsync(
            Guid publicacaoId,
            int pageNumber,
            int pageSize)
        {
            return await dataContext.WebJurComentario
                .AsNoTracking()
                .Where(x => x.WebJurPublicacaoId == publicacaoId)
                .Include(x => x.Usuario)
                .OrderByDescending(x => x.DataCadastro)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
