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
    public class ComentarioRepository(DataContext dataContext) : BaseRepository<Comentario, Guid>(dataContext), IComentarioRepository
    {
        public async Task<List<Comentario>> ObterComentarios(Guid? tarefaId, Guid? eventoId)
        {
            return await dataContext.Comentario
                .Include(c => c.Usuario) // 🔥 AQUI
                .Where(c =>
                    (tarefaId.HasValue && c.TarefaId == tarefaId) ||
                    (eventoId.HasValue && c.EventoId == eventoId)
                )
                .OrderByDescending(c => c.DataCriacao)
                .ToListAsync();
        }
        public async Task<Dictionary<Guid, int>> ContarComentariosPorCard()
        {
            return await dataContext.Comentario
                .Where(c => c.TarefaId != null || c.EventoId != null)
                .GroupBy(c => c.TarefaId ?? c.EventoId)
                .ToDictionaryAsync(g => g.Key!.Value, g => g.Count());
        }
    }
}
