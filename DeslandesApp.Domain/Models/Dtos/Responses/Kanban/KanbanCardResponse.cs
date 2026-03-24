using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Kanban
{
    public record KanbanCardResponse
    (
        Guid Id,
    string Titulo,
    DateTime? Data,
    string Tipo,
    string? Responsavel,
    Guid? ResponsavelId,
    Guid? UsuarioCriacaoId
    );
}
