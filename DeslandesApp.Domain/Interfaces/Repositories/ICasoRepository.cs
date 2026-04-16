using DeslandesApp.Domain.Models.Dtos.Responses.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Tarefa;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface ICasoRepository : IBaseRepository<Caso, Guid>
    {
        Task<PageResult<CasoPaginacaoResponse>> GetCasoPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null);
         Task<Caso> ConsultarCasoComRelacionamentosAsync(Guid idCaso);
        Task<List<CasoAutoComplete>> ConsultarCasoAutoCompleteAsync(string? termo = null);
    }
}
