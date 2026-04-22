using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
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
        public StatusGeralKanban Status { get; set; }
        public string? Responsavel { get; set; }
        public Guid? ResponsavelId { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
        public Guid? UsuarioCriacaoId { get; set; }
        public string? UsuarioCriacaoNome { get; set; }
        public DateTime? DataInicial { get; set; } // 🔥 NOVO
        public DateTime? DataFinal { get; set; }   // 🔥 NOVO
        public TimeOnly? HoraInicial { get; set; }
        public TimeOnly? HoraFinal { get; set; }
        public string PrioridadeDescricao { get; set; } = string.Empty;
    }
}

