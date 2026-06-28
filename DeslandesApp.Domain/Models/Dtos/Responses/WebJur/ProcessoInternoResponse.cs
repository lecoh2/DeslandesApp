using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.WebJur
{
    public class ProcessoInternoResponse
    {
        public Guid? ProcessoId { get; set; }

        public string NumeroInterno { get; set; }

        public string Cliente { get; set; }

        public string AdvogadoResponsavel { get; set; }

        public DateTime? ProximaAudiencia { get; set; }

        public string Status { get; set; }
    }
}
