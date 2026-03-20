using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoEnvolvidos
{
    public record GrupoCasoEnvolvidosRequest
        (
    Guid IdPessoa,
    Guid IdQualificacao
        );
}
