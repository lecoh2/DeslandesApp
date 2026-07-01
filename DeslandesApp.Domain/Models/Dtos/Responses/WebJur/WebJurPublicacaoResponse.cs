using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.WebJur
{
    public class WebJurPublicacaoResponse
    {
        public Guid Id { get; set; }

        // Campos antigos
        public int CodPublicacao { get; set; }

        public string NumeroProcesso { get; set; } = string.Empty;

        public DateTime DataPublicacao { get; set; }

        public DateTime DataCadastro { get; set; }

        public string? DespachoPublicacao { get; set; }

        public string? ProcessoPublicacao { get; set; }

        public string? VaraDescricao { get; set; }

        public string? OrgaoDescricao { get; set; }

        public bool PublicacaoCorrigida { get; set; }

        // Novos campos do WebJur
        public int AnoPublicacao { get; set; }

        public int EdicaoDiario { get; set; }

        public string? DescricaoDiario { get; set; }

        public int PaginaInicial { get; set; }

        public int PaginaFinal { get; set; }

        public DateTime? DataDivulgacao { get; set; }

        public string? UfPublicacao { get; set; }

        public string? CidadePublicacao { get; set; }

        public int CodVinculo { get; set; }

        public string? NomeVinculo { get; set; }

        public int OABNumero { get; set; }

        public string? OABEstado { get; set; }

        public string? CodIntegracao { get; set; }

        public bool PublicacaoExportada { get; set; }

        public int CodGrupo { get; set; }
    }
}
