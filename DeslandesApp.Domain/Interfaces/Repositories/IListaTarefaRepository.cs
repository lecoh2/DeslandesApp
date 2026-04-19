using DeslandesApp.Domain.Models.Dtos.Responses.ListaTarefas;
using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IListaTarefaRepository : IBaseRepository<ListaTarefa, Guid>
    {
        Task<int?> ObterMaiorOrdemPorTarefaId(Guid tarefaId);
        Task<List<ListaTarefa>> ObterPorIdsAsync(List<Guid> ids);
        Task<List<ListaTarefasResponse>> ConsultarListaTarefaAutoCompleteAsync(string? termo = null);
    }
}
