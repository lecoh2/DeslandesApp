using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Comentarios
{
    public record UpdateComentarioRequest
    {
        public Guid? TarefaId { get; init; }
        public Guid? EventoId { get; init; }
        public string Texto { get; init; } = string.Empty;
    }
}
