using DeslandesApp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Entities
{
    public class ContaBancaria
    {
        public string NomeBanco { get; set; } = string.Empty;
        public string Agencia { get; set; } = string.Empty;
        public string NumeroConta { get; set; } = string.Empty;
        public string Pix { get; set; } = string.Empty;
        #region Relacionamento Enumeradores
    public TipoConta? TipoConta { get; set; }
        #endregion
    }
}
