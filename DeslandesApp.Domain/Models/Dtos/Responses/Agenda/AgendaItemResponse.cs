using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Agenda
{
    public record AgendaItemResponse
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public DateOnly Data { get; set; }
        public TimeOnly? HoraInicio { get; set; }
        public TimeOnly? HoraFim { get; set; }

        public string Tipo { get; set; } = string.Empty; // "Tarefa" ou "Evento"

        public StatusAgenda Status { get; set; }

        public Guid? ResponsavelId { get; set; }
    }
}
