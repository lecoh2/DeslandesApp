using DeslandesApp.Domain.Models.Dtos.Requests.GrupoAtendimento;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiquetaProcesso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Atendimento
{
    public class AtendimentoClienteUpdateRequest
    {
        public string Assunto { get; init; } = string.Empty;
        public string Registro { get; init; } = string.Empty;

        // 🔥 VÍNCULO (somente 1 deve ser enviado)
        public Guid? ProcessoId { get; init; }
        public Guid? CasoId { get; init; }
        public Guid? AtendimentoPaiId { get; init; }
        public Guid? ResponsavelId { get; init; }

        public string? Observacao { get; set; }
        // 🔥 ETIQUETAS (N:N)

    }
}
