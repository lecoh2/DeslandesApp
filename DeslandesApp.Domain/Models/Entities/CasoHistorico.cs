using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class CasoHistorico :BaseEntity
    {
        public Guid CasoId { get; set; }
        public Caso Caso{ get; set; } = null!;

        public Guid? IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }

        public DateTime? DataAlteracao { get; set; } = DateTime.Now;
        public string? Observacao { get; set; }

        public string DadosAntes { get; set; } = string.Empty;
        public string DadosDepois { get; set; } = string.Empty;
    }
}
