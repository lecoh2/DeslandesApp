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
    public class AndamentoProcessoRepository(DataContext dataContext) : BaseRepository<Processo, Guid>(dataContext), IAndamentoProcessoRepository
    {
        

        public async Task<List<AndamentoProcesso>> ObterPorProcessoIdAsync(Guid processoId)
        {
            return await dataContext.AndamentosProcesso
                .Where(x => x.ProcessoId == processoId)
                .OrderByDescending(x => x.DataMovimentacao)
                .ToListAsync();
        }

        public async Task<bool> ExisteAsync(Guid processoId, DateTime dataMovimentacao, string descricao)
        {
            return await dataContext.AndamentosProcesso.AnyAsync(x =>
                x.ProcessoId == processoId &&
                x.DataMovimentacao == dataMovimentacao &&
                x.Descricao == descricao);
        }

        public async Task AdicionarAsync(AndamentoProcesso andamento)
        {
            await dataContext.AndamentosProcesso.AddAsync(andamento);
        }
    }
}
