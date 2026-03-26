using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoAtendimento;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiqueta;
using DeslandesApp.Domain.Models.Dtos.Responses.Atendimento;
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
        public async Task<PageResult<AtendimentoPaginacaoResponse>> GetAtendimentoPaginacaoAsync(
    int pageNumber,
    int pageSize,
    string? searchTerm = null)
        {
            // 1️⃣ Base da consulta (sem subcollections)
            var baseQuery = dataContext.Atendimento
                .AsNoTracking();

            // 2️⃣ Filtro de busca
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

            // 3️⃣ Total de registros
            var totalCount = await baseQuery.CountAsync();

            // 4️⃣ Paginação
            var pagedAtendimentos = await baseQuery
                .OrderBy(r => r.Assunto)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // 5️⃣ Projeção dos clientes (em memória)
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

                return new AtendimentoPaginacaoResponse
                {
                    Assunto = r.Assunto,
                    Registro = r.Registro,
                    ProcessoId = r.ProcessoId,
                    CasoId = r.CasoId,
                    AtendimentoPaiId = r.AtendimentoPaiId,
                    ResponsavelId = r.ResponsavelId,
                    GrupoAtendimentoCliente = clientes
                        .Select(c => new GrupoAtendimentoClienteRequest(c.PessoaId, c.Nome))
                        .ToList()
                };
            }).ToList();

            // 6️⃣ Retorno
            return new PageResult<AtendimentoPaginacaoResponse>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
    }
