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
    public interface IWebJurPublicacaoRepository  
    : IBaseRepository<WebJurPublicacao, Guid>
    {
        
        Task<bool> ExistePorCodigoAsync(int codPublicacao);

        Task<List<WebJurPublicacao>> ObterNaoImportadasAsync();
        Task<bool> ExisteAsync(string numeroProcesso, DateTime dataPublicacao);
        Task<List<int>> ObterCodigosExistentesAsync(List<int> codigos);
        Task<PageResult<WebJurPublicacaoResponse>> GetPaginacaoAsync(
    int pageNumber,
    int pageSize,
    string? searchTerm = null);
        Task<WebJurPublicacao?> ObterCompletoAsync(Guid id);
        Task<WebJurPublicacao?> ObterDetalheAsync(Guid id);

    }
}
