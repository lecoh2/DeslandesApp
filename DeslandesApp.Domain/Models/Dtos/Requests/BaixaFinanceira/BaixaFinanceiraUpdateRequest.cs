using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.BaixaFinanceira
{
    public class BaixaFinanceiraUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid ContaReceberId { get; set; }


        public decimal ValorPago { get; set; }


        public DateTime DataBaixa { get; set; }

        public string? Observacao { get; set; }


        public Guid FormaPagamentoId { get; set; }

        public Guid? ContaBancariaEmpresaId { get; set; }
    }
}
