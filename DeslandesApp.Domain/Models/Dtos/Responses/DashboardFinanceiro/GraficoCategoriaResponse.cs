using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.DashboardFinanceiro
{
    public class GraficoCategoriaResponse
    {
        public string Categoria { get; set; } = string.Empty;

        public decimal Valor { get; set; }
    }
}
