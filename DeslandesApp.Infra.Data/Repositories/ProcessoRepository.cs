using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Responses.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoSetores;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
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
    public class ProcessoRepository(DataContext dataContext) : BaseRepository<Processo, Guid>(dataContext), IProcessoRepository
    {

        public async Task<Processo?> ConsultarProcessoComRelacionamentosAsync(Guid idProcesso)
        {
            return await dataContext.Processos
                .Include(p => p.Vara)
                .Include(p => p.UsuarioResponsavel)
                .Include(p => p.Acao)
                // .Include(p => p.Etiqueta)
                //.Include(p => p.Instancia)
                // .Include(p => p.Acesso)
                .FirstOrDefaultAsync(p => p.Id == idProcesso);
        }


        public async Task<PageResult<ProcessoPaginacaoResponse>> GetProcessoPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {

            var query = dataContext.Processos
       .AsNoTracking()

       .AsQueryable();

            // --- filtro ---
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.ToLower();

                query = query.Where(p =>
                    p.Pasta.ToLower().Contains(term) ||
                    p.Titulo.ToLower().Contains(term) ||
                    p.NumeroProcesso.Contains(term)

                );
            }

            // --- total ---
            var totalCount = await query.CountAsync();

            var items = await query
       .OrderBy(u => u.Pasta)
       .Skip((pageNumber - 1) * pageSize)
       .Take(pageSize)
       .Select(u => new ProcessoPaginacaoResponse(
           u.Id,
           u.Pasta,
           u.Titulo,
           u.NumeroProcesso
       ))
       .ToListAsync();


            return new PageResult<ProcessoPaginacaoResponse>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<List<ProcessoAutoComplete>> ConsultarProcessoAutoCompleteAsync(string? termo = null)
        {
            var query = dataContext.Set<Processo>()
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(termo))
            {
                termo = termo.Trim();

                query = query.Where(p =>
                    p.NumeroProcesso.Contains(termo) ||
                    p.Titulo.Contains(termo) ||
                    p.Pasta.Contains(termo)
                );
            }

            return await query
                .Select(p => new ProcessoAutoComplete
                {
                    Id = p.Id,
                    Pasta = p.Pasta,
                    NumeroProcesso = p.NumeroProcesso,
                    Titulo = p.Titulo
                })
                .OrderBy(p => p.Pasta)
                .Take(20)
                .ToListAsync();
        }
        public async Task<Processo?> ObterCompletoPorIdAsync(Guid id)
        {
            return await dataContext.Processos
                .AsNoTracking()
                .Where(x => x.Id == id)

                // CLIENTES
                .Include(x => x.GrupoClienteProcesso)
                    .ThenInclude(gc => gc.Pessoa)

                // ENVOLVIDOS
                .Include(x => x.GrupoEnvolvidosProcesso)
                    .ThenInclude(ge => ge.Pessoa)

                .Include(x => x.GrupoEnvolvidosProcesso)
                    .ThenInclude(ge => ge.Qualificacao)

                // ETIQUETAS
                .Include(x => x.GrupoEtiquetasProcessos)
                    .ThenInclude(ge => ge.Etiqueta)

                // RELACIONAMENTOS
                .Include(x => x.UsuarioResponsavel)
                .Include(x => x.Acao)
                .Include(x => x.Vara)

                .FirstOrDefaultAsync();
        }
    }
}
