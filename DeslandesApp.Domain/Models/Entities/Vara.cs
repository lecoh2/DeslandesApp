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
        public string? NomeVara { get; set; }
        public Guid JuizoId { get; set; }
        public Juizo Juizo { get; set; } = null!;

        public ICollection<Foro> Foros { get; set; } = new List<Foro>();
    }
}
