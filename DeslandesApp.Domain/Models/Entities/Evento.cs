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

        public ModalidadeEvento Modalidade { get; set; } 

        public string? Observacao { get; set; }

        // 👥 Responsáveis (N:N)
        public List<GrupoEventoResponsavel> GrupoEventoResponsaveis { get; set; } = new();
        public List<GrupoEventoEtiquetas> GrupoEventoEtiquetas { get; set; } = new();
        // 🔁 Recorrência
        public TipoRecorrencia TipoRecorrencia { get; set; } = TipoRecorrencia.Nenhuma;

        public int IntervaloRecorrencia { get; set; } = 1;

        public List<DayOfWeek> DiasSemana { get; set; } = new();

        public DateOnly? DataFimRecorrencia { get; set; }

        public int? QuantidadeOcorrencias { get; set; }
        public StatusGeralKanban StatusGeralKanban { get; set; } 
        // 🔥 FUNDAMENTAL
        public Guid? UsuarioCriacaoId { get; set; }
        public Usuario? UsuarioCriacao { get; set; } // ✔ nullable também
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public TipoVinculo? TipoVinculo { get; set; }
       
        public Guid? ProcessoId { get; set; }
        public Processo? Processo { get; set; }

        public Guid? CasoId { get; set; }
        public Caso? Caso { get; set; }

        public Guid? AtendimentoId { get; set; }
        public Atendimento? Atendimento { get; set; }
        public void ValidarVinculo()
        {
            int count = 0;

            if (ProcessoId.HasValue) count++;
            if (CasoId.HasValue) count++;
            if (AtendimentoId.HasValue) count++;

            if (count > 1)
                throw new Exception("O atendimento não pode ter mais de um vínculo.");
        }

    }
}
