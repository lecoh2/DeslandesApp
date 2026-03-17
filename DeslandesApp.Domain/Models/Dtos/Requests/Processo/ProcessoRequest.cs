using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCliente;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoSetores;
using DeslandesApp.Domain.Models.Dtos.Requests.Qualificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Processo
{
    public record ProcessoRequest
    {
        public Guid? IdAcao { get; init; }
        public Guid? IdForo { get; init; }

        public string? Pasta { get; init; }
        public string? Titulo { get; init; }
        public string? NumeroProcesso { get; init; }
        public string? Juizo { get; init; }
        public string? Vara { get; init; }
        public string? LinkTribunal { get; init; }
        public string? Objeto { get; init; }
        public decimal? ValorCausa { get; init; }
        public DateOnly? Distribuido { get; init; }
        public decimal? ValorCondenacao { get; init; }
        public string? Observacao { get; init; }
        public string? Responsavel { get; init; }
        public DateTime? DataCadastro { get; set; }
        // 🔥 RELACIONAMENTOS
        public List<GrupoClienteRequset>? GrupoCliente { get; set; }
        public List<GrupoEnvolvidosRequest>? GrupoEnvolvidos{ get; init; }
        // 🔥 IGUAL VOCÊ FEZ NA PESSOA (CORRETO)
       
    }
}
