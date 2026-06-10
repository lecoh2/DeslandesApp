using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.BaixaFinanceira
{
    public class ConsultarBaixaFinanceiraResponse
    {
        public Guid Id { get; set; }

        public decimal ValorPago { get; set; }

        public DateTime DataBaixa { get; set; }

        public string? Observacao { get; set; }

        public Guid ContaReceberId { get; set; }

        public string? Cliente { get; set; }

        public string? FormaPagamento { get; set; }

        public Guid? ContaBancariaEmpresaId { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
