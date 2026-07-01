using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IWebJurComentarioRepository
    {
        Task AdicionarAsync(WebJurComentario comentario);

        Task<List<WebJurComentario>> ObterPorPublicacaoAsync(Guid publicacaoId);
        Task<List<WebJurComentario>> ObterPaginadoAsync(Guid publicacaoId, int pageNumber, int pageSize);
    }
}
