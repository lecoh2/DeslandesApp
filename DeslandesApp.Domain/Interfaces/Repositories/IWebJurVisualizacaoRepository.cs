using DeslandesApp.Domain.Models.Dtos.Responses.WebJur;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IWebJurVisualizacaoRepository
    {
        Task AdicionarAsync(WebJurVisualizacao visualizacao);

        Task<List<WebJurVisualizacao>> ObterPorPublicacaoAsync(Guid publicacaoId);
        Task<PageResult<WebJurVisualizacaoResponse>> GetPaginacaoAsync(
                    Guid publicacaoId,
                    int pageNumber,
                    int pageSize);

    }
}
