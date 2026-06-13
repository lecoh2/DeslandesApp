using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.BaixaFinanceira
{
    public class BaixaFinanceiraRequest
    {
       
        public Guid? ContaReceberId { get; set; }

        public Guid? ContaPagarId { get; set; }
        public decimal ValorPago { get; set; }


        public DateTime DataBaixa { get; set; }

        public string? Observacao { get; set; }


        public FormaRecebimento FormaRecebimento { get; set; }

        public Guid? ContaBancariaEmpresaId { get; set; }
    }
}
