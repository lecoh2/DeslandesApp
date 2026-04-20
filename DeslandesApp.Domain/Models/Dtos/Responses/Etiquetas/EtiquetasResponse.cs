using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Etiquetas
{
    public record EtiquetaResponse 
    (
        Guid? Id,

    string? Nome,
    string? Cor
);
}
