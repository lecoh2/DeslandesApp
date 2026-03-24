using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class KanbanCard
    {
        public Guid Id { get; set; } // só se precisar
        public string Titulo { get; set; } = string.Empty;
        public DateTime? Data { get; set; }
        public string Tipo { get; set; } = string.Empty;

        public string? Responsavel { get; set; }
        public Guid? ResponsavelId { get; set; }

        public Guid? UsuarioCriacaoId { get; set; }
    }
}
