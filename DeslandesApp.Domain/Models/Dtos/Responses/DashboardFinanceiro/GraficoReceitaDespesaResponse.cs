using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.DashboardFinanceiro
{
    public class GraficoReceitaDespesaResponse
    {
        public string Mes { get; set; } = string.Empty;

        public decimal Receitas { get; set; }

        public decimal Despesas { get; set; }
    }
}
