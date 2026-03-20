using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Tarefa;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class TarefaRepository(DataContext dataContext) : BaseRepository<Tarefa, Guid>(dataContext), ITarefaRepository
    {
        public Task<PageResult<TarefaPaginacaoResponse>> GetProcessoPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {
            throw new NotImplementedException();
        }
    }
}
