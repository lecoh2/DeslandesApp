using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public abstract class InformacoesComplementares : BaseEntity
    {

        public string? Codigo { get; set; } = string.Empty;
        public string? Comentario { get; set; } = string.Empty;
        #region Reacionamento
        public Guid IdPessoa { get; set; }
        public virtual Pessoa? Pessoa { get; set; }
        #endregion
    }
}
