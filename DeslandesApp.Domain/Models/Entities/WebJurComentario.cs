using DeslandesApp.Domain.Commons;
using DocumentFormat.OpenXml.Vml.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class WebJurComentario : BaseEntity
    {
        public Guid WebJurPublicacaoId { get; set; }

        public Guid UsuarioId { get; set; }

        public string Comentario { get; set; }

        public DateTime DataCadastro { get; set; }

        public virtual WebJurPublicacao WebJurPublicacao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
