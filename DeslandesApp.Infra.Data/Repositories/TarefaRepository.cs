using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Tarefa;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class TarefaRepository(DataContext dataContext) : BaseRepository<Tarefa, Guid>(dataContext), ITarefaRepository
    {
        public async Task<PageResult<TarefaPaginacaoResponse>> GetTarefaPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {

            var query = dataContext.Tarefas
       .AsNoTracking()

       .AsQueryable();

            // --- filtro ---
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.ToLower();
                query = query.Where(p =>
                       p.Descricao.ToLower().Contains(term) ||

                       (p.Responsavel != null &&
                        p.Responsavel.NomeUsuario.ToLower().Contains(term)) ||
                       p.StatusGeralKanban.ToString().ToLower().Contains(term)

                               );
            }

            // --- total ---
            var totalCount = await query.CountAsync();

            var items = await query
       .OrderBy(u => u.DataTarefa)
       .Skip((pageNumber - 1) * pageSize)
       .Take(pageSize)
       .Select(u => new TarefaPaginacaoResponse
       {
           Id = u.Id,
           Descricao = u.Descricao,
           DataTarefa = u.DataTarefa,
           Responsavel = u.Responsavel == null ? null : new UsuarioResumoResponse(
    u.Responsavel.Id,
    u.Responsavel.NomeUsuario
),
           Prioridade = u.Prioridade,
           TipoVinculo = u.TipoVinculo,
           StatusGeralKanban = u.StatusGeralKanban
       })
       .ToListAsync();


            return new PageResult<TarefaPaginacaoResponse>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

    }
}
