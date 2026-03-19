using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Vara : BaseEntity
    {
        public string NomeVara { get; set; } = string.Empty; // Ex: "2ª Vara Cível"
        public int Numero { get; set; } // 2
        public string Tipo { get; set; } = string.Empty; // Cível, Criminal...

        public Guid ForoId { get; set; }
        public Foro Foro { get; set; } = null!;

        public ICollection<Processo> Processos { get; set; } = new List<Processo>();
    }
}
