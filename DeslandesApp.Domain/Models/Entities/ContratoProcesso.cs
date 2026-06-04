using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class ContratoProcesso
    {
        public Guid ContratoId { get; set; }
        public Contrato Contrato { get; set; }

        public Guid ProcessoId { get; set; }
        public Processo Processo { get; set; }
    }
}
