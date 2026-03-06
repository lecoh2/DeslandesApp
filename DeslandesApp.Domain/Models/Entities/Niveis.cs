using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Niveis : BaseEntity
    {
      //  public Guid IdNivel { get; set; }
        public string? NomeNivel { get; set; }
        //public Status? Status { get; set; }
        public ICollection<GrupoNiveis> GrupoNiveis { get; set; } = new List<GrupoNiveis>();
    }
}
