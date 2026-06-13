using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class BaixaContaPagar : BaseEntity
    {
        public Guid ContaPagarId { get; set; }
        public ContaPagar ContaPagar { get; set; }

        public DateTime DataPagamento { get; set; }

        public decimal ValorPago { get; set; }

        public FormaRecebimento FormaPagamento { get; set; }

        public string? Observacao { get; set; }
    }
}
