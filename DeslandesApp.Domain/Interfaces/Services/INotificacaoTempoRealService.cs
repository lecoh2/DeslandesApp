using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface INotificacaoTempoRealService
    {
        Task EnviarAsync(Guid usuarioId, object dados);
        Task AtualizarNotificacaoLidaAsync(Guid usuarioId, Guid notificacaoId);
    }
}
