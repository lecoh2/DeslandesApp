using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Setor : BaseEntity
    {
       // public Guid IdSetor { get; set; }
        public string? NomeSetor { get; set; }

        public ICollection<GrupoSetores> GrupoSetores { get; set; } = new List<GrupoSetores>();
    }
}
