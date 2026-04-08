using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class GrupoPessoasEtiquetas
    {
        public Guid EtiquetaId { get; set; }
        public Guid PessoaId { get; set; }
        // public Guid IdNivel { get; set; }

        public Etiqueta Etiqueta { get; set; }
        public Pessoa Pessoa{ get; set; }
    }
}
