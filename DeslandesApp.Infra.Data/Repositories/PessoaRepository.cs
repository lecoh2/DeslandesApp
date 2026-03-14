using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoSetores;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Domain.ValueObjects;
using DeslandesApp.Infra.Data.Contexts;
using DeslandesApp.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PessoaRepository(DataContext dataContext)
        : BaseRepository<Pessoa, Guid>(dataContext), IPessoaRepository
{
    public async Task<bool> CpfInUseAsync(string cpf)
    {
        return await dataContext
            .Set<PessoaFisica>()
            .AsNoTracking()
            .AnyAsync(p => p.CPF == cpf);
    }

    public async Task<bool> RgInUseAsync(string rg)
    {
        return await dataContext
            .Set<PessoaFisica>()
            .AsNoTracking()
            .AnyAsync(p => p.RG == rg);
    }

    public async Task<bool> EmailInUseAsync(string email)
    {
        return await dataContext
            .Set<Pessoa>()
            .AsNoTracking()
            .AnyAsync(p => p.ValorEmail == new ValorEmail(email));
    }

    public async Task<PessoaFisica?> GetByCpfAsync(string cpf)
    {
        return await dataContext
            .Set<PessoaFisica>()
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.CPF == cpf);
    }

    public async Task<bool> CnpjInUseAsync(string cnpj)
    {
        return await dataContext
             .Set<PessoaJuridica>()
             .AsNoTracking()
             .AnyAsync(p => p.CNPJ == cnpj);
    }

    public async Task<bool> IncricaoEstadualInUseAsync(string incricaoEstadual)
    {
        return await dataContext
            .Set<PessoaJuridica>()
            .AsNoTracking()
            .AnyAsync(p => p.InscricaoEstadual == incricaoEstadual);
    }

    public async Task<PageResult<PessoaFisicaPaginacaoResponse>> PessoaFisicaComPaginacaoAsync(
     int pageNumber, int pageSize, string? searchTerm = null)
    {
        // --- 1️⃣ Base da consulta: somente leitura, sem tracking ---
        var query = dataContext.PessoasFisicas
            .AsNoTracking()
            .Select(p => new
            {
                p.Id,
                p.Nome,
                p.ValorEmail,
                p.CPF,
                p.RG,
                p.Telefone
            });

        // --- 2️⃣ Aplicar filtro (apenas quando necessário) ---
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var term = searchTerm.ToLower();

            query = query.Where(p =>
                p.Nome.ToLower().Contains(term) ||
                (p.ValorEmail != null ? p.ValorEmail.EnderecoEmail : "")
                    .ToLower()
                    .Contains(term) ||
                (p.CPF ?? "").Contains(term) ||
                (p.RG ?? "").Contains(term) ||
                (p.Telefone ?? "").Contains(term)
            );
        }

        // --- 3️⃣ Contagem total (executa COUNT apenas) ---
        var totalCount = await query.CountAsync();

        // --- 4️⃣ Paginação + projeção final ---
        var items = await query
          .OrderBy(p => p.Nome)
          .Skip((pageNumber - 1) * pageSize)
          .Take(pageSize)
          .Select(p => new PessoaFisicaPaginacaoResponse(
              p.Id,
              p.Nome,
              p.CPF,
              p.RG,
              p.ValorEmail.EnderecoEmail,
              p.Telefone
          ))
          .ToListAsync();
        ////

        // --- 5️⃣ Retornar o resultado ---
        return new PageResult<PessoaFisicaPaginacaoResponse>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }
}

