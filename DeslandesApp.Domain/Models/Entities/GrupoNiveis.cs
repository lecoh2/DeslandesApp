using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class GrupoNiveis
    {
        public Guid IdUsuario { get; set; }
        public Guid IdNivel { get; set; }

        public Usuario Usuario { get; set; }
        public Niveis Niveis { get; set; }
    }
}
