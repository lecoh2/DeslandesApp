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
    public class GrupoEnvolvidosRepository(DataContext dataContext)
        : BaseRepository<GrupoEnvolvidos, Guid>(dataContext), IGrupoEnvolvidosRepository
    {
        public async Task<GrupoEnvolvidos> GetByIdEnvolvido(Guid idCliene, Guid idProcesso, Guid IdQualificacao)
        {
            return await dataContext.GrupoEnvolvidos
              .FirstOrDefaultAsync(gc => gc.PessoaId == idCliene && gc.ProcessoId == idProcesso && gc.QualificacaoId == IdQualificacao);
        }

        public async Task<GrupoEnvolvidos> ExistEnvolvidoProcessoAsync(Guid idCliene, Guid idProcesso, Guid IdQualificacao)
        {
            throw new NotImplementedException();
        }

      
    }
}
