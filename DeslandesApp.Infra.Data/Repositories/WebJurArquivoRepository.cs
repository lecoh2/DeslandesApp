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
    public class WebJurArquivoRepository(DataContext dataContext) : IWebJurArquivoRepository
    {
        public async Task AdicionarAsync(WebJurArquivo arquivo)
        {
            await dataContext.WebJurArquivo.AddAsync(arquivo);
        }

        public async Task<List<WebJurArquivo>> ObterPorPublicacaoAsync(Guid publicacaoId)
        {
            return await dataContext.WebJurArquivo
                .Where(x => x.WebJurPublicacaoId == publicacaoId)
                .OrderByDescending(x => x.DataCadastro)
                .ToListAsync();
        }
    }
}
