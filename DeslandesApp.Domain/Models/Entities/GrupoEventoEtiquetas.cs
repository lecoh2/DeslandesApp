using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{

    public class GrupoEventoEtiquetas
    {
        public Guid EventoId { get; set; }
        public Evento Evento{ get; set; } = null!;

        public Guid EtiquetaId { get; set; }
        public Etiqueta Etiqueta { get; set; } = null!;
    }
}
