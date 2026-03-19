using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Evento : BaseEntity
    {
        public string Titulo { get; set; } = string.Empty;

        public DateOnly DataInicial { get; set; }
        public TimeOnly HoraInicial { get; set; }

        public DateOnly? DataFinal { get; set; }
        public TimeOnly? HoraFinal { get; set; }

        public bool DiaInteiro { get; set; }

        public string? Endereco { get; set; }

        public ModalidadeEvento Modalidade { get; set; } = ModalidadeEvento.NaoSeAplica;

        public string? Observacao { get; set; }

        // 🔗 Vínculo dinâmico
        public Guid? EntidadeId { get; set; }
        public TipoVinculoEvento? TipoVinculo { get; set; }

        // 👥 Responsáveis (N:N)
        public List<GrupoEventoResponsavel> GrupoEventoResponsavel { get; set; } = new();

    }
}
