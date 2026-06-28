using DeslandesApp.Domain.Models.Dtos.Responses.Comentarios;
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

        public string NumeroProcesso { get; set; }

        public string TipoPublicacao { get; set; }

        public string VaraDescricao { get; set; }

        public string OrgaoDescricao { get; set; }

        public DateTime DataPublicacao { get; set; }

        public string TextoPublicacao { get; set; }

        public ProcessoInternoResponse ProcessoInterno { get; set; }

        public List<WebJurComentarioResponse> Comentarios { get; set; } = new();

        public List<WebJurMovimentacaoResponse> Movimentacoes { get; set; } = new();

        public List<WebJurArquivoResponse> Arquivos { get; set; } = new();

        public List<WebJurVisualizacaoResponse> Visualizacoes { get; set; } = new();

        public List<WebJurSincronizacaoResponse> Sincronizacoes { get; set; } = new();
    }
}
