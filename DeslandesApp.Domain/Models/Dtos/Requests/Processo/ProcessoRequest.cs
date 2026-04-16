using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCliente;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoClienteProceso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEnvolvidosProcesso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiqueta;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiquetaProcesso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoSetores;
using DeslandesApp.Domain.Models.Dtos.Requests.Qualificacao;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Processo
{
    public record ProcessoRequest
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
           public int? Instancia { get; set; }
        public int? Acesso { get; set; }
            // 🔥 RELACIONAMENTOS N:N
            public List<GrupoClienteProcessoRequest>? GrupoClienteProcesso { get; init; }
            public List<GrupoEnvolvidosProcessoRequest>? GrupoEnvolvidosProcesso { get; init; }
        public List<GrupoEtiquetaProcessoRequest> GrupoEtiquetasProcesso { get; init; } = new();
    }

    }

