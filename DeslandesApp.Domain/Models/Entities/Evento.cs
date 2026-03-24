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

        // 👥 Responsáveis (N:N)
        public List<GrupoEventoResponsavel> GrupoEventoResponsavel { get; set; } = new();

        // 🔁 Recorrência
        public TipoRecorrencia TipoRecorrencia { get; set; } = TipoRecorrencia.Nenhuma;

        public int IntervaloRecorrencia { get; set; } = 1;

        public List<DayOfWeek> DiasSemana { get; set; } = new();

        public DateOnly? DataFimRecorrencia { get; set; }

        public int? QuantidadeOcorrencias { get; set; }
        public StatusGeralKanban StatusGeralKanban { get; set; } = StatusGeralKanban.A_Fazer;
        // 🔥 FUNDAMENTAL
        public Guid? UsuarioCriacaoId { get; set; }
        public Usuario? UsuarioCriacao { get; set; } // ✔ nullable também
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
