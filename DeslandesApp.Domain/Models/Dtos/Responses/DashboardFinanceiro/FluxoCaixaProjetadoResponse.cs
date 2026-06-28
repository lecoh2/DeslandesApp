using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.DashboardFinanceiro
{
    //public class FluxoCaixaProjetadoResponse
    //{
    //    public DateTime Data { get; set; }

    //    public decimal PrevistoReceber { get; set; }

    //    public decimal PrevistoPagar { get; set; }

    //    public decimal SaldoProjetado { get; set; }
    //}

    public class FluxoCaixaProjetadoResponse
    {
        public DateTime Data { get; set; }

        public decimal PrevistoReceber { get; set; }

        public decimal PrevistoPagar { get; set; }

        public decimal SaldoDia { get; set; }

        public decimal SaldoAcumulado { get; set; }
    }
}
