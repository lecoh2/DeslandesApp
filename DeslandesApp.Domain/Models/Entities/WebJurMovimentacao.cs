using DeslandesApp.Domain.Commons;
using DocumentFormat.OpenXml.Vml.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class WebJurMovimentacao : BaseEntity
    {
        public Guid WebJurPublicacaoId { get; set; }

        public DateTime DataMovimentacao { get; set; }

        public string Tipo { get; set; }

        public string Descricao { get; set; }

        public string Origem { get; set; }

        public virtual WebJurPublicacao WebJurPublicacao { get; set; }
    }
}
