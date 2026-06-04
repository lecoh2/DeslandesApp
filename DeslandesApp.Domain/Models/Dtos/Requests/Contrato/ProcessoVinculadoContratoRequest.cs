using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Contrato
{
    public class ProcessoVinculadoContratoRequest
    {
        public string NumeroProcesso { get; set; }
        public string NumeroContrato { get; set; }
    }
}
