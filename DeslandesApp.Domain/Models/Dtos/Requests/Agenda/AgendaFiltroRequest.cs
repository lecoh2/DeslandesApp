using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Agenda
{
    public record AgendaFiltroRequest
    {
        public Guid? UsuarioId { get; set; }

        public bool FiltrarPorResponsavel { get; set; }
        public bool FiltrarPorEnvolvido { get; set; }
        public bool FiltrarPorCriador { get; set; }

        public Guid? PessoaId { get; set; }

        public bool IncluirTarefas { get; set; } = true;
        public bool IncluirEventos { get; set; } = true;

        public List<StatusAgenda>? Status { get; set; }

        public DateOnly? DataInicio { get; set; }
        public DateOnly? DataFim { get; set; }
    }
}
