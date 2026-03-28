using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class ProcessoEtiqueta
    {
        public Guid ProcessoId { get; set; }
        public Processo Processo { get; set; } = null!;

        public Guid EtiquetaId { get; set; }
        public Etiqueta Etiqueta { get; set; } = null!;
    }
}
