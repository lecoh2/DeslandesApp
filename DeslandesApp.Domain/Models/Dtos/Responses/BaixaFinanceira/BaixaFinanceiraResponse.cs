using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.BaixaFinanceira
{
    public class BaixaFinanceiraResponse
    {
        public Guid Id { get; set; }

        public decimal ValorPago { get; set; }

        public DateTime DataPagamento { get; set; }

        public string? Observacao { get; set; }
    }
}
