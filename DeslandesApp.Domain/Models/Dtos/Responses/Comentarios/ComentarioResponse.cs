using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Comentarios
{
    public record ComentarioResponse
    {
        public Guid Id { get; init; }
        public string Texto { get; init; } = string.Empty;
        public DateTime DataCriacao { get; init; }
        public string UsuarioNome { get; init; } = string.Empty;
    }
}
