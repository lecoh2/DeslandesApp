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
        public Guid Id { get; set; }
        public string Titulo { get; set; }

        public DateOnly DataInicial { get; set; }
        public TimeOnly HoraInicial { get; set; }

        public DateOnly? DataFinal { get; set; }
        public TimeOnly? HoraFinal { get; set; }

        public bool DiaInteiro { get; set; }

        public string? Endereco { get; set; }

        public ModalidadeEvento Modalidade { get; set; }

        public string? Observacao { get; set; }

        public StatusGeralKanban? StatusGeralKanban { get; set; }

        public Guid? ProcessoId { get; set; }
        public Guid? CasoId { get; set; }
        public Guid? AtendimentoId { get; set; }

        public TipoVinculo? TipoVinculo { get; set; }
        public List<GrupoEventoResponsavelResponse>? GrupoEventoResponsaveis { get; set; }
        public List<GrupoEventoEtiquetasResponse>? GrupoEventoEtiquetas { get; set; }
    }
}
