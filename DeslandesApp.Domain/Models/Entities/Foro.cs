using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Foro : BaseEntity
    {
        public string NomeForo { get; set; } = string.Empty;

        public ICollection<Vara> Varas { get; set; } = new List<Vara>();
    }
}
