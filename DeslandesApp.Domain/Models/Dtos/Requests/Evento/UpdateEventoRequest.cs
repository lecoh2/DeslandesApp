using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Evento
{
    public record UpdateEventoRequest
    {
        public string Titulo { get; init; }

        public DateOnly DataInicial { get; init; }
        public TimeOnly HoraInicial { get; init; }

        public DateOnly? DataFinal { get; init; }
        public TimeOnly? HoraFinal { get; init; }

        public bool DiaInteiro { get; init; }

        public string? Endereco { get; init; }

        public ModalidadeEvento Modalidade { get; init; }

        public string? Observacao { get; init; }

        // 👥 SOMENTE IDS (CORRETO)
       // public List<GrupoEventoResponsavelRequest>? GrupoEventoResponsavel { get; init; }

        // 🔁 Recorrência
        public TipoRecorrencia TipoRecorrencia { get; init; }
        public int IntervaloRecorrencia { get; init; }
        public List<DayOfWeek>? DiasSemana { get; init; }
        public DateOnly? DataFimRecorrencia { get; init; }
        public int? QuantidadeOcorrencias { get; init; }
        //public StatusEvento? Status { get; init; }
        public StatusGeralKanban? StatusKaban { get; set; }
    }
}
