using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Pessoas
{
    public record PessoaResumoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; } // CPF ou CNPJ
        public string Tipo { get; set; } // "Fisica" ou "Juridica"
    }
}
