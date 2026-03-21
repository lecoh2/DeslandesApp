using DeslandesApp.Domain.Models.Dtos.Requests.GrupoAtendimento;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiqueta;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Atendimento
{
    public record CriarAtendimentoClienteRequest
    {

        public string Assunto { get; init; } = string.Empty;
        public string Registro { get; init; } = string.Empty;

        // 🔥 VÍNCULO (somente 1 deve ser enviado)
        public Guid? ProcessoId { get; init; }
        public Guid? CasoId { get; init; }
        public Guid? AtendimentoPaiId { get; init; }
        public Guid? ResponsavelId { get; init; }
       // public TipoVinculo TipoVinculo { get; init; }

        // 🔥 ETIQUETAS (N:N)
        public List<GrupoEtiquetaRequest> GrupoEtiquetas { get; init; } = new();

        // 🔥 CLIENTES (N:N)
        public List<GrupoAtendimentoClienteRequest> GrupoAtendimentoCliente { get; init; } = new();
    }
}

