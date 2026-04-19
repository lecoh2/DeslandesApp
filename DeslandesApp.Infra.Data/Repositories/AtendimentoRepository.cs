using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoAtendimento;

using DeslandesApp.Domain.Models.Dtos.Responses.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoAtendimentoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaAtendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
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
    public class AtendimentoRepository(DataContext dataContext)
        : BaseRepository<Atendimento, Guid>(dataContext), IAtendimentoRepository
    {
        public async Task<Atendimento> ConsultarAtendimentoComRelacionamentosAsync(Guid idAtendimento)
        
               
        {
            return await dataContext.Atendimento
                .Include(p => p.Caso)
                .Include(p => p.Responsavel)
                .Include(p => p.Processo)
                .Include(p => p.AtendimentoPai)               
                .FirstOrDefaultAsync(p => p.Id == idAtendimento);
        }
        

        public async Task<PageResult<AtendimentoPaginacaoResponse>> GetAtendimentoPaginacaoAsync(
       int pageNumber,
       int pageSize,
       string? searchTerm = null)
        {
            var baseQuery = dataContext.Atendimento
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.ToLower();

                baseQuery = baseQuery.Where(r =>
                    r.Assunto.ToLower().Contains(term) ||
                    r.Registro.ToLower().Contains(term) ||

                    dataContext.GrupoAtendimentoCliente
                        .Where(gc => gc.AtendimentoId == r.Id)
                        .Any(gc =>

                            dataContext.PessoasFisicas
                                .Where(pf => pf.Id == gc.PessoaId)
                                .Select(pf => pf.Nome.ToLower())
                                .FirstOrDefault()
                                .Contains(term)

                            ||

                            dataContext.PessoaJuridica
                                .Where(pj => pj.Id == gc.PessoaId)
                                .Select(pj => pj.Nome.ToLower())
                                .FirstOrDefault()
                                .Contains(term)
                        )
                );
            }

            var totalCount = await baseQuery.CountAsync();

            var pagedAtendimentos = await baseQuery
                .OrderBy(r => r.Assunto)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var items = pagedAtendimentos.Select(r =>
            {
                var clientes = dataContext.GrupoAtendimentoCliente
                    .Where(gc => gc.AtendimentoId == r.Id)
                    .Select(gc => new
                    {
                        gc.PessoaId,
                        Nome = dataContext.PessoasFisicas
                            .Where(pf => pf.Id == gc.PessoaId)
                            .Select(pf => pf.Nome)
                            .FirstOrDefault()
                            ?? dataContext.PessoaJuridica
                            .Where(pj => pj.Id == gc.PessoaId)
                            .Select(pj => pj.Nome)
                            .FirstOrDefault()
                    })
                    .ToList();

                var etiquetas = dataContext.GrupoEtiquetasAtendimentos
                    .Where(ge => ge.AtendimentoId == r.Id)
                    .Select(ge => new
                    {
                        ge.EtiquetaId,
                        Nome = ge.Etiqueta.Nome
                    })
                    .ToList();

                return new AtendimentoPaginacaoResponse
                {
                    Assunto = r.Assunto,
                    Registro = r.Registro,
                    ProcessoId = r.ProcessoId,
                    CasoId = r.CasoId,
                    AtendimentoPaiId = r.AtendimentoPaiId,
                    ResponsavelId = r.ResponsavelId,

                    GrupoAtendimentoCliente = clientes
                        .Select(c => new GrupoAtendimentoClienteResponse
                        {
                            PessoaId = c.PessoaId,
                            Nome = c.Nome
                        })
                        .ToList(),

                    GrupoAtendimentoEtiqueta = etiquetas
                        .Select(e => new GrupoEtiquetaAtendimentoResponse
                        {
                            EtiquetaId = e.EtiquetaId,
                            Nome = e.Nome
                        })
                        .ToList()
                };
            }).ToList();

            // ✅ RETURN CORRETO (fora do Select)
            return new PageResult<AtendimentoPaginacaoResponse>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<List<AtendimentoAutoComplete>> ConsultarAtendimentoAutoCompleteAsync(string? termo = null)
        {
            var query = dataContext.Set<Atendimento>()
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(termo))
            {
                termo = termo.Trim().ToLower();

                query = query.Where(p =>
                    p.Assunto.ToLower().Contains(termo)
                );
            }

            return await query
                .Select(p => new AtendimentoAutoComplete
                {
                    Id = p.Id,
                    Assunto = p.Assunto
                })
                .OrderBy(p => p.Assunto)
                .Take(20) // 🔥 MUITO importante pra autocomplete
                .ToListAsync();
        }
    }
}
