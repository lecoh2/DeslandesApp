using DeslandesApp.Domain.Interfaces.Repositories;
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
    public class PessoaHistoricoRepository(DataContext dataContext)
        : BaseRepository<PessoaHistorico, Guid>(dataContext), IPessoaHistoricoRepository
    {
        public async Task<List<PessoaHistorico>> ConsultarPessoaFisicaHistoricoComRelacionamentosAsync(Guid id)
        
            {
                return await dataContext.PessoaHistorico
                    .Include(h => h.Usuario)
                    .ThenInclude(h => h.Pessoa)
                   // .Include(h => (h.Pessoa as PessoaFisica).Sexo)
                    .Include(h => (h.Pessoa as PessoaFisica).Endereco)
                    .Where(h => h.Pessoa is PessoaFisica && h.IdPessoa == id)
                    .OrderByDescending(h => h.DataAlteracao)
                    .ToListAsync();            
        }

        public Task<List<PessoaHistorico>> ConsultarPessoaJuridicaHistoricoComRelacionamentosAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
