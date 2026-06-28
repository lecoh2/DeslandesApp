using DeslandesApp.Domain.Commons;
using DocumentFormat.OpenXml.Vml.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class WebJurArquivo : BaseEntity
    {
        public Guid WebJurPublicacaoId { get; set; }

        public string NomeArquivo { get; set; }

        public string CaminhoArquivo { get; set; }

        public string TipoArquivo { get; set; }

        public DateTime DataCadastro { get; set; }

        public virtual WebJurPublicacao WebJurPublicacao { get; set; }
    }
}
