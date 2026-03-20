using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class GrupoAtendimentoEtiqueta
    {
        public Guid AtendimentoId { get; set; }
        public Atendimento Atendimento { get; set; }

        public Guid EtiquetaId { get; set; }
        public Etiqueta Etiqueta { get; set; }
    }
}

