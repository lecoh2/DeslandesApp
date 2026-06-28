using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IWebJurMovimentacaoRepository
    {
        Task AdicionarAsync(WebJurMovimentacao movimentacao);

        Task<List<WebJurMovimentacao>> ObterPorPublicacaoAsync(Guid publicacaoId);
    }
}
