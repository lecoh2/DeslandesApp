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
        public string? NomeBanco { get; set; } = string.Empty;
        public string? Agencia { get; set; } = string.Empty;
        public string? NumeroConta { get; set; } = string.Empty;
        public string? Pix { get; set; } = string.Empty;
        #region Relacionamento Enumeradores
        public TipoConta? TipoConta { get; set; }
        #endregion
    }
}

