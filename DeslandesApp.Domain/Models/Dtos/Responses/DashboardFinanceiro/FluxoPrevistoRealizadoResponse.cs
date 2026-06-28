using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.DashboardFinanceiro
{
    public class FluxoPrevistoRealizadoResponse
    {
        public string Mes { get; set; } = string.Empty;

        public decimal Previsto { get; set; }

        public decimal Realizado { get; set; }
    }
}
