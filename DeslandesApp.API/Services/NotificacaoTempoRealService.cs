using DeslandesApp.API.Hubs;
using DeslandesApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;

namespace DeslandesApp.API.Services
{
    public class NotificacaoTempoRealService : INotificacaoTempoRealService
    {
        private readonly IHubContext<NotificationHub> _hub;

        public NotificacaoTempoRealService(IHubContext<NotificationHub> hub)
        {
            _hub = hub;
        }

        public async Task EnviarAsync(Guid usuarioId, object dados)
        {

            await _hub.Clients
      .Group(usuarioId.ToString())
      .SendAsync("ReceberNotificacao", dados);

        }
        public async Task AtualizarNotificacaoLidaAsync(Guid usuarioId, Guid notificacaoId)
        {
            await _hub.Clients
                .Group(usuarioId.ToString())
                .SendAsync("NotificacaoLida", notificacaoId);
        }
    }
}