using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DeslandesApp.Infra.Data.Repositories
{

    public class ConfiguracaoFinanceiraRepository(DataContext dataContext) : BaseRepository<ConfiguracaoFinanceira, Guid>(dataContext),
          IConfiguracaoFinanceiraRepository
    {
      

        public async Task<ConfiguracaoFinanceira?>
            ObterAsync()
        {
            return await dataContext
                .ConfiguracaoFinanceira
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task AdicionarAsync(
            ConfiguracaoFinanceira configuracao)
        {
            await dataContext
                .ConfiguracaoFinanceira
                .AddAsync(configuracao);
        }

        public void Atualizar(
            ConfiguracaoFinanceira configuracao)
        {
            dataContext
                .ConfiguracaoFinanceira
                .Update(configuracao);
        }
    }
}