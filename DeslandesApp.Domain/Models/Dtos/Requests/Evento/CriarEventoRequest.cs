using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Evento
{
    public record CriarEventoRequest
    {
        public string Titulo { get; init; } = string.Empty;

        public DateOnly DataInicial { get; init; }
        public TimeOnly HoraInicial { get; init; }

        public DateOnly? DataFinal { get; init; }
        public TimeOnly? HoraFinal { get; init; }

        public bool DiaInteiro { get; init; }

        public string? Endereco { get; init; }

        public ModalidadeEvento Modalidade { get; init; } = ModalidadeEvento.NaoSeAplica;

        public string? Observacao { get; init; }

        public Guid? EntidadeId { get; init; }
        public TipoVinculo? TipoVinculo { get; init; }

        public List<Guid> ResponsaveisIds { get; init; } = new();
    }
}
