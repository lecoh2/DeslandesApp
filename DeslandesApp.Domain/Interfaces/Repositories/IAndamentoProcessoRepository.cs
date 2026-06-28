using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IAndamentoProcessoRepository
    {
        Task<List<AndamentoProcesso>> ObterPorProcessoIdAsync(Guid processoId);

        Task<bool> ExisteAsync(Guid processoId, DateTime dataMovimentacao, string descricao);

        Task AdicionarAsync(AndamentoProcesso andamento);
    }
}
