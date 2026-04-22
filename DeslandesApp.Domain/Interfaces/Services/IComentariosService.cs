using DeslandesApp.Domain.Models.Dtos.Requests.Comentarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Comentarios;
using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IComentarioService : IBaseService<CriarComentarioRequest, UpdateComentarioRequest, ComentarioResponse, Guid>
    {
        Task<Comentario> CriarComentario(CriarComentarioRequest request);
        Task<List<Comentario>> ObterComentarios(Guid? tarefaId, Guid? eventoId);
    }
}
