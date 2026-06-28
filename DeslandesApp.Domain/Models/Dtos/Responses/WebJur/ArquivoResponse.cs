using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.WebJur
{
    public class ArquivoResponse
    {
        public Guid Id { get; set; }

        public string NomeArquivo { get; set; }

        public string TipoArquivo { get; set; }

        public string Url { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
