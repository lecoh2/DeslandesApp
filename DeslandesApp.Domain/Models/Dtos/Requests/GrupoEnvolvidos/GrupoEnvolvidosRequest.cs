using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.GrupoEnvolvidos
{
    public record GrupoEnvolvidosRequest
    (Guid IdPessoa,
    Guid IdQualificacao);
}
