using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Kanban
{
    public record KanbanColunaResponse
    {
        public string Nome { get; init; }
        public string Cor { get; init; }
        public List<KanbanCardResponse> Cards { get; init; }
    }
}
