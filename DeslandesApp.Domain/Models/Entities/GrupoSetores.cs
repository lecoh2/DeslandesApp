using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class GrupoSetores
    {
        public Guid IdUsuario { get; set; }
        public Guid IdSetor { get; set; }
        // public Guid IdNivel { get; set; }

        public Usuario Usuario { get; set; }
        public Setor Setor { get; set; }
        // public Niveis Nivel { get; set; }
    }
}
