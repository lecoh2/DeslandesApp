using DeslandesApp.Domain.Commons;
using DocumentFormat.OpenXml.Vml.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class WebJurVisualizacao : BaseEntity
    {
        public Guid WebJurPublicacaoId { get; set; }

        public Guid UsuarioId { get; set; }

        public DateTime DataVisualizacao { get; set; }

        public string Ip { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual WebJurPublicacao WebJurPublicacao { get; set; }
    }
}
