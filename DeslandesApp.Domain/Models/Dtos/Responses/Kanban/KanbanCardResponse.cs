using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Kanban
{
    public record KanbanCardResponse
    {
        public Guid Id { get; init; }
        public string Titulo { get; init; } = string.Empty;
        public DateTime? Data { get; init; }
        public string Tipo { get; init; } = string.Empty;
        public int Status { get; init; }
        public int QuantidadeComentarios { get; init; }
        public string? VinculoDescricao { get; init; }
    }
}
