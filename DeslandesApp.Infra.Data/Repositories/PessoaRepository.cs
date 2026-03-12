using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
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

   
}

