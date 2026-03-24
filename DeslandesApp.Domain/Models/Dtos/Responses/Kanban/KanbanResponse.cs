using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Kanban
{
    public record KanbanResponse
    {
        public List<KanbanColuna> Colunas { get; set; } = new();
    }
}
