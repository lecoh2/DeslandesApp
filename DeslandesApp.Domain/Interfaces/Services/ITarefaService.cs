using DeslandesApp.Domain.Models.Dtos.Requests.Kaban;
using DeslandesApp.Domain.Models.Dtos.Requests.ListaTarefas;
using DeslandesApp.Domain.Models.Dtos.Requests.Processo;
using DeslandesApp.Domain.Models.Dtos.Requests.Tarefa;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Tarefa;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface ITarefaService : IBaseService<CriarTarefaRequest, TarefaUpdateRequest, CriarTarefaResponse, Guid>
    {
        Task ReordenarListaAsync(List<ReordenarListaTarefaRequest> request);
        Task MoverCardAsync(MoverKanbanCardRequest request);
        Task AtualizarStatusTarefasAutomatico();
        Task<PageResult<TarefaPaginacaoResponse>> ConsultarTarefaPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null);


    }
}
