using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetasProcessos
{
    public record GrupoEtiquetasProcessosResponse
    { 
        public Guid IdEtiqueta { get; init; }
        public Guid IdProcesso { get; init; }
        public string Nome { get; init; }
        public string Cor { get; init; }
    }
}
