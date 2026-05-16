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
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly DataContext context;

        public NotificacaoRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Notificacao entity)
        {
            await context.Notificacoes.AddAsync(entity);
        }

        public async Task<Notificacao?> GetByIdAsync(Guid id)
        {
            return await context.Notificacoes.FindAsync(id);
        }

        public async Task<List<Notificacao>> ObterPorUsuarioAsync(Guid usuarioId)
        {
            return await context.Notificacoes
                .Where(x =>
                    x.UsuarioId == usuarioId &&
                    !x.Lida
                )
                .OrderByDescending(x => x.DataCriacao)
                .Take(50)
                .ToListAsync();
        }

        public void Update(Notificacao entity)
        {
            context.Notificacoes.Update(entity);
        }
        public async Task<List<Notificacao>> GetAllAsync()
        {
            return await context.Notificacoes
                .Where(x => !x.Lida)
                .OrderByDescending(x => x.DataCriacao)
                .Take(50)
                .ToListAsync();
        }
    }
}
