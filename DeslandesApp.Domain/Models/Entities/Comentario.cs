using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Comentario : BaseEntity
    {
        public string Texto { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        // 🔗 VÍNCULO (GENÉRICO)
        public Guid? TarefaId { get; set; }
        public Tarefa? Tarefa { get; set; }

        public Guid? EventoId { get; set; }
        public Evento? Evento { get; set; }
    }
}
