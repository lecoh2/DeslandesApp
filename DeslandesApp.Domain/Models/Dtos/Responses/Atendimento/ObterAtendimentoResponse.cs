using DeslandesApp.Domain.Models.Dtos.Responses.GrupoAtendimentoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaAtendimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Atendimento
{
    public record ObterAtendimentoResponse
    {
        public Guid? Id { get; init; }
        public string Assunto { get; init; } = string.Empty;
        public string Registro { get; init; } = string.Empty;

        public Guid? ProcessoId { get; init; }
        public Guid? CasoId { get; init; }
        public Guid? AtendimentoPaiId { get; init; }
        public Guid? ResponsavelId { get; init; }

        //  public List<GrupoTarefasEtiquetasRequest> GrupoTarefasEtiquetas { get; init; } = new();

        // 🔥 CLIENTES (N:N)
        public List<GrupoAtendimentoClienteResponse> GrupoAtendimentoCliente { get; init; } = new();
        public List<GrupoEtiquetaAtendimentoResponse> GrupoAtendimentoEtiqueta { get; init; } = new();

    }
}
