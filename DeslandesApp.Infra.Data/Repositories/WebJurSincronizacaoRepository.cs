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
    public class WebJurSincronizacaoRepository(DataContext dataContext) : IWebJurSincronizacaoRepository
    {
        public async Task AdicionarAsync(WebJurSincronizacao sincronizacao)
        {
            await dataContext.WebJurSincronizacao.AddAsync(sincronizacao);
        }

        public async Task<List<WebJurSincronizacao>> ObterPorPublicacaoAsync(Guid publicacaoId)
        {
            return await dataContext.WebJurSincronizacao
                .Include(x => x.Usuario)
                .Where(x => x.WebJurPublicacaoId == publicacaoId)
                .OrderByDescending(x => x.Inicio)
                .ToListAsync();
        }
    }
}
