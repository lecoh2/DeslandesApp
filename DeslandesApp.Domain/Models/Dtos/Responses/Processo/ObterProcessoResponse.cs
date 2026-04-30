using DeslandesApp.Domain.Models.Dtos.Requests.GrupoClienteProceso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEnvolvidosProcesso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiquetaProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoClienteProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEnvolvidosProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetasProcessos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Processo
{
    public class ObterProcessoResponse
    {
        public Guid? AcaoId { get; init; }
        public Guid VaraId { get; init; }
        public Guid? UsuarioResponsavelId { get; init; }

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
        public Guid? ForoId { get; set; }
        public string? NomeForo { get; set; }
        public int? NumeroVara { get; set; }
        public string? NomeVara { get; set; }
        public string? Juizo { get; set; }
        public List<GrupoClienteProcessoResponse>? GrupoClienteProcesso { get; init; }
        public List<GrupoEnvolvidosProcessoResponse>? GrupoEnvolvidosProcesso { get; init; }
        public List<GrupoEtiquetasProcessosResponse>? GrupoEtiquetasProcesso { get; init; }
    }
}
