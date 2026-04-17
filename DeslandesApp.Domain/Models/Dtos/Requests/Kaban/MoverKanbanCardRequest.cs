using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests
{
    public class MoverKanbanCardRequest
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; } = string.Empty; // "Tarefa" ou "Evento"
        public StatusGeralKanban NovoStatus { get; set; }
    }
}
