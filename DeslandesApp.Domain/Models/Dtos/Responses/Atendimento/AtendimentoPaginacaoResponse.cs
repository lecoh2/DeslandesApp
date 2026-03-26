using DeslandesApp.Domain.Models.Dtos.Requests.GrupoAtendimento;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiqueta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Atendimento
{
    public record AtendimentoPaginacaoResponse
    {
        public string Assunto { get; init; } = string.Empty;
        public string Registro { get; init; } = string.Empty;

        public Guid? ProcessoId { get; init; }
        public Guid? CasoId { get; init; }
        public Guid? AtendimentoPaiId { get; init; }
        public Guid? ResponsavelId { get; init; }
 
        public List<GrupoEtiquetaRequest> GrupoEtiquetas { get; init; } = new();

        // 🔥 CLIENTES (N:N)
        public List<GrupoAtendimentoClienteRequest> GrupoAtendimentoCliente { get; init; } = new();
    }
}
