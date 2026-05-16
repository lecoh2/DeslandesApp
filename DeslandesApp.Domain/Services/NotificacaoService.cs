using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly INotificacaoTempoRealService realtime;

        public NotificacaoService(
            IUnitOfWork unitOfWork,
            INotificacaoTempoRealService realtime)
        {
            this.unitOfWork = unitOfWork;
            this.realtime = realtime;
        }

        public async Task CriarNotificacaoAsync(
     Guid usuarioId,
     string titulo,
     string mensagem,
     TipoEntidade tipo,
     Guid? entidadeId)
        {
            var notificacao = new Notificacao
            {
                UsuarioId = usuarioId,
                Titulo = titulo,
                Mensagem = mensagem,

                Tipo = tipo,               // 🔥 AGORA CORRETO
                EntidadeId = entidadeId,   // 🔥 AGORA CORRETO

                Lida = false,
                DataCriacao = DateTime.Now
            };

            await unitOfWork.NotificacaoRepository.AddAsync(notificacao);
            await unitOfWork.CommitAsync();

            await realtime.EnviarAsync(usuarioId, new
            {
                titulo,
                mensagem,
                tipo,
                entidadeId
            });
        }
        public async Task MarcarComoLidaAsync(Guid notificacaoId)
        {
            var notificacao =
                await unitOfWork.NotificacaoRepository.GetByIdAsync(notificacaoId);

            if (notificacao == null)
                throw new Exception("Notificação não encontrada");

            notificacao.Lida = true;

            unitOfWork.NotificacaoRepository.Update(notificacao);

            await unitOfWork.CommitAsync();

            // 🔥 SIGNALR REALTIME
            await realtime.AtualizarNotificacaoLidaAsync(
                notificacao.UsuarioId,
                notificacao.Id
            );
        }
        public async Task<List<Notificacao>> ObterNotificacoesUsuarioAsync(Guid usuarioId)
        {
            var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(usuarioId);

            if (usuario == null)
                throw new ApplicationException("Usuário não encontrado.");

            var ehAdmin = usuario.GrupoNiveis
                .Any(x => x.Niveis != null &&
                          x.Niveis.NomeNivel == "Administrador");

            if (ehAdmin)
            {
                return await unitOfWork.NotificacaoRepository.GetAllAsync();
            }

            return await unitOfWork.NotificacaoRepository
                .ObterPorUsuarioAsync(usuarioId);
        }
    }
}
