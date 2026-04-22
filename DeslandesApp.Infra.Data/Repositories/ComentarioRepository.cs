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
            var query = dataContext.Comentario.AsQueryable();

            if (tarefaId.HasValue)
                query = query.Where(c => c.TarefaId == tarefaId);

            if (eventoId.HasValue)
                query = query.Where(c => c.EventoId == eventoId);

            return await query
                .OrderByDescending(c => c.DataCriacao)
                .ToListAsync();
        }
    }
}
