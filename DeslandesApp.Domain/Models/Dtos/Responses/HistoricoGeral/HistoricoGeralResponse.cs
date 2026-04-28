using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.HistoricoGeral
{
    public record HistoricoGeralResponse
    {
        public TipoEntidade Entidade { get; init; }
        public Guid EntidadeId { get; init; }

        public DateTime DataAlteracao { get; init; }
        public string? Observacao { get; init; }

        public string UsuarioNome { get; init; } = string.Empty;

        public string DadosAntes { get; init; } = string.Empty;
        public string DadosDepois { get; init; } = string.Empty;
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }
    }

}
