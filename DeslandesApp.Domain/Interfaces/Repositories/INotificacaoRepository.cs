using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface INotificacaoRepository
    {
        Task AddAsync(Notificacao entity);
        Task<Notificacao?> GetByIdAsync(Guid id);
        Task<List<Notificacao>> ObterPorUsuarioAsync(Guid usuarioId);
        void Update(Notificacao entity);
        Task<List<Notificacao>> GetAllAsync();
    }
}
