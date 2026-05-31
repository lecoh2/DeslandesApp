using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.BaixaFinanceira
{
    public class BaixaFinanceiraRequest
    {
        public decimal ValorPago { get; set; }

        public DateTime DataPagamento { get; set; }

        public string? Observacao { get; set; }
    }
}
