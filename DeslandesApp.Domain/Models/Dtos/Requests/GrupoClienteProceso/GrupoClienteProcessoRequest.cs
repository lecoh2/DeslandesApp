using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.GrupoClienteProceso
{
    public record GrupoClienteProcessoRequest
    {
        public Guid? IdPessoa { get; init; }
        public Guid? IdQualificacao { get; init; }
    }
}
