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
       

        public Guid TarefaId { get; set; }
        public Tarefa Tarefa { get; set; } = null!;

        public Guid ProcessoId { get; set; }
        public Processo Processo { get; set; } = null!;

        public Guid? ResponsavelId { get; set; }
        public Pessoa? Responsavel { get; set; }
        #region Relacionamentos

        public PrioridadeTarefa Prioridade { get; set; } = PrioridadeTarefa.Media;

        public List<GrupoTarefaEnvolvido> GrupoTarefaEnvolvido { get; set; } = new List<GrupoTarefaEnvolvido>();
        #endregion
    }
}
