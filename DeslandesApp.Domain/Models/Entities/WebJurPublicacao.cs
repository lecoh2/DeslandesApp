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
        public int CodPublicacao { get; set; }

        public string NumeroProcesso { get; set; } = string.Empty;

        public DateTime DataPublicacao { get; set; }

        public DateTime DataCadastroWebJur { get; set; }

        public string? DespachoPublicacao { get; set; }

        public string? ProcessoPublicacao { get; set; }

        public string? VaraDescricao { get; set; }

        public string? OrgaoDescricao { get; set; }

        public bool PublicacaoCorrigida { get; set; }

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
