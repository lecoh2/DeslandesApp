using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class InformacoesComplementaresPessoaJuridica : InformacoesComplementares
    {
        public string? Contato { get; set; }
        public string? Cargo { get; set; } = string.Empty;
     
        public string? Comentario { get; set; } = string.Empty;

    }
}
