using DeslandesApp.Domain.Models.Dtos.Requests.GrupoAtendimento;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiquetaProcesso;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Atendimento
{
    public class AtendimentoClienteUpdateRequest
    {
        public string Assunto { get; init; } = string.Empty;
        public string Registro { get; init; } = string.Empty;

        // 🔗 VÍNCULO
        public Guid? ProcessoId { get; init; }
        public Guid? CasoId { get; init; }
        public Guid? AtendimentoPaiId { get; init; }
        public Guid? ResponsavelId { get; init; }

        public string? Observacao { get; set; }

        // =========================
        // 👥 CLIENTES (N:N)
        // =========================
        public List<GrupoAtendimentoClienteRequest> GrupoAtendimentoCliente { get; set; } = new();

        // =========================
        // 🏷️ ETIQUETAS (N:N)
        // =========================
        public List<GrupoEtiquetaAtendimentoRequest> GrupoAtendimentoEtiqueta { get; set; } = new();
    }
}