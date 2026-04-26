using DeslandesApp.Domain.Models.Dtos.Requests;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEventoEtiquetas;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEventoEtiquetas;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEventoResponsavel;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Evento
{
    public class ObterEventoResponse
    {
        public Guid Id { get; init; }
        public string Titulo { get; init; }

        public DateOnly DataInicial { get; init; }
        public TimeOnly HoraInicial { get; init; }

        public DateOnly? DataFinal { get; init; }
        public TimeOnly? HoraFinal { get; init; }

        public bool DiaInteiro { get; init; }

        public string? Endereco { get; init; }

        public ModalidadeEvento Modalidade { get; init; }

        public string? Observacao { get; init; }

        public StatusGeralKanban StatusGeralKanban { get; init; }

        public Guid? ProcessoId { get; init; }
        public Guid? CasoId { get; init; }
        public Guid? AtendimentoId { get; init; }

        public TipoVinculo? TipoVinculo { get; init; }
        public List<GrupoEventoResponsavelResponse>? GrupoEventoResponsaveis { get; init; }
        public List<GrupoEventoEtiquetasResponse>? GrupoEventoEtiquetas { get; init; }
        public string? ProcessoPasta { get; init; }
        public string? CasoPasta { get; init; }
        public string? AtendimentoAssunto { get; init; }
    }
}
