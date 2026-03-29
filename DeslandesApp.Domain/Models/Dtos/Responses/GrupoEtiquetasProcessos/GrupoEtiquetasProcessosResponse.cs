using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetasProcessos
{
    public record GrupoEtiquetasProcessosResponse
     (Guid idEtiqueta,
      Guid idProcesso,
      string nome
        );
}
