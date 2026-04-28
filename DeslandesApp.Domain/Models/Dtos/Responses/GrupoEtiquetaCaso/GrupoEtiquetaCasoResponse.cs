using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaCaso
{
    public class GrupoEtiquetaCasoResponse
    {
        public Guid? EtiquetaId { get; set; }
        public string? Nome { get; set; }
        public string? Cor { get; set; }

    }
}
