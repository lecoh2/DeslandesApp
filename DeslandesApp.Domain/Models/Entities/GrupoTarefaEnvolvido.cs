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
        public Guid ListaTarefaId { get; set; }
        public ListaTarefa? ListaTarefa { get; set; } = null!;

        public Guid UsuarioId { get; set; }
        public Usuario Usuario{ get; set; } = null!;
    }
}
