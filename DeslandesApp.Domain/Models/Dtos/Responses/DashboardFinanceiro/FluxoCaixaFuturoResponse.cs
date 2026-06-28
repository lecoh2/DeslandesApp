using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.DashboardFinanceiro
{
    public class FluxoCaixaFuturoResponse
    {
        public string Periodo { get; set; } = string.Empty;

        public decimal Entradas { get; set; }

        public decimal Saidas { get; set; }

        public decimal Saldo { get; set; }
    }
}
