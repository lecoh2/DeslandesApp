using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class WebJurPublicacao : BaseEntity
    {
        // Identificação
        public int CodPublicacao { get; set; }
        public string NumeroProcesso { get; set; } = string.Empty;

        // Datas principais
        public DateTime DataPublicacao { get; set; }
        public DateTime DataCadastroWebJur { get; set; }
        public DateTime? DataDivulgacao { get; set; }

        // Dados do processo
        public string? VaraDescricao { get; set; }
        public string? OrgaoDescricao { get; set; }
        public string? DespachoPublicacao { get; set; }
        public string? ProcessoPublicacao { get; set; }
        public bool PublicacaoCorrigida { get; set; }

        // Dados extras do WebJur
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

        // Controle interno do sistema
        public bool Importada { get; set; }
        public Guid? ProcessoId { get; set; }

        public Processo? Processo { get; set; }
        public virtual ICollection<WebJurComentario> Comentarios { get; set; } = new List<WebJurComentario>();

        public virtual ICollection<WebJurMovimentacao> Movimentacoes { get; set; } = new List<WebJurMovimentacao>();

        public virtual ICollection<WebJurArquivo> Arquivos { get; set; } = new List<WebJurArquivo>();

        public virtual ICollection<WebJurVisualizacao> Visualizacoes { get; set; } = new List<WebJurVisualizacao>();

        public virtual ICollection<WebJurSincronizacao> Sincronizacoes { get; set; } = new List<WebJurSincronizacao>();
    }
}
