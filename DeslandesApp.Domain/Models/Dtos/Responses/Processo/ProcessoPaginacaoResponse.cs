using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Processo
{
    public record ProcessoPaginacaoResponse
    (
        Guid Id,
             string? Pasta,
             string NumeroProcesso,
             string? Tirulo
    );
}
