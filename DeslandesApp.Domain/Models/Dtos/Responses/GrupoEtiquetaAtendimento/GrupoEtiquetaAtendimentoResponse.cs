using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaAtendimento
{
    public record GrupoEtiquetaAtendimentoResponse
    {
        public Guid? EtiquetaId { get; init; }

        public string? Nome { get; init; }
    }
}
