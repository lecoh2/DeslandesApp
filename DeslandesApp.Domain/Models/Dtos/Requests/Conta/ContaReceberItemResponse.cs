using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Conta
{
    public class ContaReceberItemResponse
    {
        public Guid Id { get; set; }
        public int NumeroParcela { get; set; }
        public int TotalParcelas { get; set; }

        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }

        public StatusConta Status { get; set; }
    }
}
