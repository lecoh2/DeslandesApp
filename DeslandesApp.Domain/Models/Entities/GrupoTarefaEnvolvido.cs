using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class GrupoTarefaEnvolvido : BaseEntity
    {
        public Guid TarefaId { get; set; }
        public Tarefa Tarefa { get; set; } = null!;

        public Guid PessoaId { get; set; }
        public Pessoa Pessoa{ get; set; } = null!;
    }
}
