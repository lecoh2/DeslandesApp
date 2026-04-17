using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Responses.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
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
    public class CasoRepository(DataContext dataContext)
        : BaseRepository<Caso, Guid>(dataContext), ICasoRepository
    {
        public async Task<PageResult<CasoPaginacaoResponse>> GetCasoPaginacaoAsync(
     int pageNumber,
     int pageSize,
     string? searchTerm = null)
        {
            // 1️⃣ Base query
            var query = dataContext.Caso
                .AsNoTracking()
                .AsQueryable();

            // 2️⃣ Filtro
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.ToLower();

                query = query.Where(p =>
                    p.Pasta.ToLower().Contains(term) ||
                    p.Titulo.ToLower().Contains(term) ||

                    (p.Responsavel != null &&
                     p.Responsavel.NomeUsuario.ToLower().Contains(term)) ||

                    dataContext.GrupoCasoCliente
                        .Where(gc => gc.CasoId == p.Id)
                        .Any(gc =>

                            dataContext.PessoasFisicas
                                .Any(pf => pf.Id == gc.PessoaId &&
                                           pf.Nome.ToLower().Contains(term))

                            ||

                            dataContext.PessoaJuridica
                                .Any(pj => pj.Id == gc.PessoaId &&
                                           pj.Nome.ToLower().Contains(term))
                        )
                );
            }

            // 3️⃣ Total
            var totalCount = await query.CountAsync();

            // 4️⃣ Paginação
            var pagedCasos = await query
                .OrderBy(p => p.Pasta)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var casosIds = pagedCasos.Select(c => c.Id).ToList();

            // 5️⃣ 🔥 Buscar envolvidos (AGORA TIPADO)
            var envolvidosDb = await dataContext.GrupoCasoCliente
                .Where(gc => casosIds.Contains(gc.CasoId))
                .Select(gc => new EnvolvidoTemp
                {
                    CasoId = gc.CasoId,
                    PessoaId = gc.PessoaId,
                    //QualificacaoId = gc.QualificacaoId,

                    Nome = dataContext.PessoasFisicas
                        .Where(pf => pf.Id == gc.PessoaId)
                        .Select(pf => pf.Nome)
                        .FirstOrDefault()
                        ?? dataContext.PessoaJuridica
                            .Where(pj => pj.Id == gc.PessoaId)
                            .Select(pj => pj.Nome)
                            .FirstOrDefault(),

                    //NomeQualificacao = dataContext.Qualificacao
                    //    .Where(q => q.Id == gc.QualificacaoId)
                    //    .Select(q => q.NomeQualificacao)
                    //    .FirstOrDefault()
                })
                .ToListAsync();

            // 6️⃣ Agrupar por caso
            var envolvidosPorCaso = envolvidosDb
                .GroupBy(e => e.CasoId)
                .ToDictionary(g => g.Key, g => g.ToList());

            // 7️⃣ Montagem final (🔥 CORRIGIDO)
            var items = pagedCasos.Select(u =>
            {
                var envolvidos = envolvidosPorCaso.ContainsKey(u.Id)
                    ? envolvidosPorCaso[u.Id]
                    : new List<EnvolvidoTemp>(); // ✅ corrigido

                return new CasoPaginacaoResponse
                {
                    Id = u.Id,
                    Titulo = u.Titulo,
                    DataCadastro = u.DataCadastro ?? DateTime.MinValue,

                    Responsavel = u.Responsavel == null
                        ? null
                        : new UsuarioResumoResponse(
                            u.Responsavel.Id,
                            u.Responsavel.NomeUsuario
                        ),

                    // ✅ COMPLETO
                    GrupoCasoClientes = envolvidos
                        .Select(c => new GrupoCasoClienteResponse(
                            c.PessoaId,
                            c.CasoId,
                            c.Nome
                        //c.QualificacaoId ?? Guid.Empty,
                        //c.NomeQualificacao
                        ))
                        .ToList(),

                    // ✅ ENVOLVIDOS (exibição)
                    GrupoCasoEnvolvidos = envolvidos
                        .Select(c => new GrupoCasoEnvolvidosResponse(
                            c.PessoaId,
                            c.Nome,
                            c.QualificacaoId ?? Guid.Empty,
                            c.NomeQualificacao
                        ))
                        .ToList()
                };
            }).ToList();

            // 8️⃣ Retorno
            return new PageResult<CasoPaginacaoResponse>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Caso> ConsultarCasoComRelacionamentosAsync(Guid idCaso)
        {
            return await dataContext.Caso
                .Include(p => p.Responsavel)

                .FirstOrDefaultAsync(p => p.Id == idCaso);
        }

        public async Task<List<CasoAutoComplete>> ConsultarCasoAutoCompleteAsync(string? termo = null)
        {
            var query = dataContext.Set<Caso>()
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(termo))
            {
                termo = termo.Trim();

                query = query.Where(p =>
                    p.Pasta.Contains(termo) ||
                    p.Titulo.Contains(termo)
                );
            }

            return await query
                .Select(p => new CasoAutoComplete
                {
                    Id = p.Id,
                    Titulo = p.Titulo
                })
                .OrderBy(p => p.Titulo)
                .Take(20)
                .ToListAsync();
        }
    }
}

