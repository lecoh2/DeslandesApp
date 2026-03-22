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
        public string? Descricao { get; set; } = string.Empty;

        public bool? Concluida { get; set; } = false;

        public DateTime? DataConclusao { get; set; }

        public Guid? TarefaId { get; set; }
        public Tarefa? Tarefa { get; set; } = null!;

        public int? Ordem { get; set; }
    }
}


