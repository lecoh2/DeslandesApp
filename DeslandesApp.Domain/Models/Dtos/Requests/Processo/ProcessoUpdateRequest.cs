using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCliente;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEnvolvidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Processo
{
    public record ProcessoUpdateRequest
    {
        public Guid? AcaoId { get; init; }

        // 🔥 RELACIONAMENTO CORRETO
        public Guid VaraId { get; init; }

        // 👤 RESPONSÁVEL
        public Guid? UsuarioResponsavelId { get; init; }

        // 📄 DADOS DO PROCESSO
        public string? Pasta { get; init; }
        public string? Titulo { get; init; }
        public string? NumeroProcesso { get; init; }
        public string? LinkTribunal { get; init; }
        public string? Objeto { get; init; }
        public decimal? ValorCausa { get; init; }
        public DateOnly? Distribuido { get; init; }
        public decimal? ValorCondenacao { get; init; }
        public string? Observacao { get; init; }

        // 🔥 RELACIONAMENTOS N:N
        public List<GrupoClienteRequset>? GrupoCliente { get; init; }
        public List<GrupoEnvolvidosRequest>? GrupoEnvolvidos { get; init; }
    }
}
