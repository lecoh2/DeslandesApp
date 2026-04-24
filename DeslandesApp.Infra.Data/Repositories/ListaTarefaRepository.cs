using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Responses.ListaTarefas;
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
    public class ListaTarefaRepository(DataContext dataContext) : BaseRepository<ListaTarefa, Guid>(dataContext), IListaTarefaRepository
    {
        public async Task<int?> ObterMaiorOrdemPorTarefaId(Guid tarefaId)
        {
            return await dataContext.ListasTarefa
                .Where(x => x.TarefaId == tarefaId)
                .MaxAsync(x => (int?)x.Ordem);
        }
        public async Task<List<ListaTarefa>> ObterPorIdsAsync(List<Guid> ids)
        {
            return await dataContext.ListasTarefa
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }

        public async Task<List<ListaTarefasResponse>> ConsultarListaTarefaAutoCompleteAsync(string? termo = null)
        {
            var query = dataContext.ListaTarefa
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(termo))
            {
                termo = termo.Trim();

                query = query.Where(x =>
                    x.Descricao.Contains(termo)
                );
            }

            var dados = await query
                .GroupBy(x => x.Descricao)
                .Select(g => new
                {
                    Descricao = g.Key,
                    Quantidade = g.Count()
                })
                .OrderByDescending(x => x.Quantidade)
                .Take(20)
                .ToListAsync();

            return dados
      .Select(x => new ListaTarefasResponse
      {
          Descricao = x.Descricao,
          Quantidade = x.Quantidade
      })
      .ToList();
        }
        public async Task RemoverPorTarefaId(Guid tarefaId)
        {
            var registros = await dataContext.ListasTarefa
                .Where(x => x.TarefaId == tarefaId)
                .ToListAsync();

            dataContext.ListasTarefa.RemoveRange(registros);
        }
    }
    }

