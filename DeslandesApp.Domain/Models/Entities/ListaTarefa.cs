using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{

    public class ListaTarefa : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid TarefaId { get; set; }

        // 🔥 FALTAVA ISSO
        public Tarefa Tarefa { get; set; } = null!;

        public Guid VinculoId { get; set; }
        public TipoVinculo TipoVinculo { get; set; }

        public Guid? ResponsavelId { get; set; }
        public Usuario? Responsavel { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }

        public List<GrupoTarefaEnvolvido> GrupoTarefaEnvolvido { get; set; } = new();
    }
}

