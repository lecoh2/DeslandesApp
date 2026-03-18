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
    public class GrupoClientesRepository(DataContext dataContext)
        : BaseRepository<GrupoPessoaClientes, Guid>(dataContext), IGrupoClientesRepository
    {
        public async Task<GrupoPessoaClientes> ExistClienteProcessoAsync(Guid idCliene, Guid idProcesso, Guid IdQualificacao)
        {
            return await dataContext.GrupoPessoaClientes
              .FirstOrDefaultAsync(gc => gc.PessoaId == idCliene && gc.ProcessoId == idProcesso && gc.QualificacaoId == IdQualificacao);
        }

        public async Task<GrupoPessoaClientes> GetByIdCliente(Guid idCliene, Guid idProcesso, Guid IdQualificacao)
        {
            return await dataContext.GrupoPessoaClientes

        .Where(gc => gc.PessoaId == idCliene && gc.ProcessoId == idProcesso && gc.QualificacaoId == IdQualificacao)
        .FirstOrDefaultAsync();
        }
    }
}
