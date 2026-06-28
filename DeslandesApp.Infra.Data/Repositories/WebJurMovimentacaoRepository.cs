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
    public class WebJurMovimentacaoRepository(DataContext dataContext) : IWebJurMovimentacaoRepository
    {
        public async Task AdicionarAsync(WebJurMovimentacao movimentacao)
        {
            await dataContext.WebJurMovimentacao.AddAsync(movimentacao);
        }

        public async Task<List<WebJurMovimentacao>> ObterPorPublicacaoAsync(Guid publicacaoId)
        {
            return await dataContext.WebJurMovimentacao
                .Where(x => x.WebJurPublicacaoId == publicacaoId)
                .OrderByDescending(x => x.DataMovimentacao)
                .ToListAsync();
        }
    }
}

