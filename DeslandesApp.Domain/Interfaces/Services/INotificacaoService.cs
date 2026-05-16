using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface INotificacaoService
    {
        Task CriarNotificacaoAsync(
  Guid usuarioId,
  string titulo,
  string mensagem,
  TipoEntidade tipo,
  Guid? entidadeId);

        Task<List<Notificacao>> ObterNotificacoesUsuarioAsync(
            Guid usuarioId
        );

        Task MarcarComoLidaAsync(
            Guid notificacaoId
        );
    }
}
