using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoEventoEtiquetas
{
    public record GrupoEventoEtiquetasResponse
    {
        public Guid? EtiquetaId { get; init; }

        public string? Nome { get; init; }
        public string? Cor { get; set; }
    }
}
