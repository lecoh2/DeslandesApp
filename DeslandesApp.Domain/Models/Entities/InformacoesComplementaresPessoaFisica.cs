using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class InformacoesComplementaresPessoaFisica : InformacoesComplementares
    {
        public string DataNascimento { get; set; }
        public string? NomeEmpresa { get; set; } = string.Empty;
        public string? Profissao { get; set; } = string.Empty;
        public string? AtividadeEconomica { get; set; } = string.Empty;
        public string? EstadoCivil { get; set; } = string.Empty;
        public string? NomePai { get; set; } = string.Empty;
        public string? NomeMae { get; set; } = string.Empty;
        public string? Naturalidade { get; set; } = string.Empty;
        public string? Nacionalidade { get; set; } = string.Empty;
       
    }
}
