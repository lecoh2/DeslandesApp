using DeslandesApp.Domain.Models.Dtos.Responses.Comentarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.WebJur
{
    public class WebJurPublicacaoDetalheResponse
    {
        public Guid Id { get; set; }

        public int CodPublicacao { get; set; }

        public string NumeroProcesso { get; set; } = string.Empty;

        public string? TipoPublicacao { get; set; }

        public string? VaraDescricao { get; set; }

        public string? OrgaoDescricao { get; set; }

        public DateTime DataPublicacao { get; set; }

        public DateTime DataCadastroWebJur { get; set; }

        public DateTime? DataDivulgacao { get; set; }

        public string? TextoPublicacao { get; set; }

        public bool PublicacaoCorrigida { get; set; }

        public bool Importada { get; set; }

        public Guid? ProcessoId { get; set; }

        // =========================
        // Dados adicionais do WebJur
        // =========================

        public int AnoPublicacao { get; set; }

        public int EdicaoDiario { get; set; }

        public string? DescricaoDiario { get; set; }

        public int PaginaInicial { get; set; }

        public int PaginaFinal { get; set; }

        public string? UfPublicacao { get; set; }

        public string? CidadePublicacao { get; set; }

        public int CodVinculo { get; set; }

        public string? NomeVinculo { get; set; }

        public int OABNumero { get; set; }

        public string? OABEstado { get; set; }

        public string? CodIntegracao { get; set; }

        public bool PublicacaoExportada { get; set; }

        public int CodGrupo { get; set; }
        public ProcessoWebJurResumoResponse? Processo { get; set; }
        public List<WebJurComentarioResponse> Comentarios { get; set; } = [];
        public List<WebJurVisualizacaoResponse> Visualizacoes { get; set; } = [];
        public List<WebJurMovimentacaoResponse> Movimentacoes { get; set; } = [];
        public List<WebJurArquivoResponse> Arquivos { get; set; } = [];
        public List<WebJurSincronizacaoResponse> Sincronizacoes { get; set; } = [];

    }
}
