using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class ContaReceberBaixa
    {
        public Guid Id { get; set; }

        public Guid ContaReceberId { get; set; }

        public decimal ValorPago { get; set; }

        public DateTime DataBaixa { get; set; }

        public FormaRecebimento FormaRecebimento { get; set; }

        public string? Observacao { get; set; }

        public virtual ContaReceber? ContaReceber { get; set; }



    }
}
