using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Tarefa : BaseEntity
    {
        public string Descricao { get; set; } = string.Empty;
        public DateTime? DataTarefa { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DataAtualizacao { get; set; }

        // 🔗 Vinculos opcionais
        public Guid? ProcessoId { get; set; }
        public Processo? Processo { get; set; }

        public Guid? CasoId { get; set; }
        public Caso? Caso { get; set; }

        public Guid? AtendimentoId { get; set; }
        public Atendimento? Atendimento { get; set; }

        public Guid? ResponsavelId { get; set; }
        public Usuario? Responsavel { get; set; }

        public PrioridadeTarefa Prioridade { get; set; }

        public List<TarefaEtiqueta> TarefaEtiquetas { get; set; } = new();
        public List<ListaTarefa> ListasTarefa { get; set; } = new();
        public List<GrupoTarefaEnvolvido> GrupoTarefaEnvolvido { get; set; } = new();
        public TipoVinculo? TipoVinculo { get; set; }
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
