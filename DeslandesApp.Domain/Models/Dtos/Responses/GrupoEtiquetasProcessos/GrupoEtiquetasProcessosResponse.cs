using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetasProcessos
{
    public class GrupoEtiquetasProcessosResponse
    {
        public Guid IdEtiqueta { get; set; }
        public Guid IdProcesso { get; set; }
        public string? Nome { get; set; }
        public string? Cor { get; set; }
    }
}
