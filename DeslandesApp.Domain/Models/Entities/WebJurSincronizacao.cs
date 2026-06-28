using DeslandesApp.Domain.Commons;
using DocumentFormat.OpenXml.Vml.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class WebJurSincronizacao : BaseEntity
    {
        public Guid WebJurPublicacaoId { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime? Fim { get; set; }

        public bool Sucesso { get; set; }

        public string Mensagem { get; set; }

        public Guid UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual WebJurPublicacao WebJurPublicacao { get; set; }
    }
}
