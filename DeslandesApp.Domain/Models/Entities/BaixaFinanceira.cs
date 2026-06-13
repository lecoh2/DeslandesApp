using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class BaixaFinanceira : BaseEntity
    {

        public decimal ValorPago { get; set; }
        public DateTime DataBaixa { get; set; }

        public string? Observacao { get; set; }

        // =========================
        // vínculo RECEBER (opcional)
        // =========================
        public Guid? ContaReceberId { get; set; }
        public ContaReceber? ContaReceber { get; set; }

        // =========================
        // vínculo PAGAR (opcional)
        // =========================
        public Guid? ContaPagarId { get; set; }
        public ContaPagar? ContaPagar { get; set; }


        public FormaRecebimento FormaRecebimento { get; set; }
        public Guid? ContaBancariaEmpresaId { get; set; }

        public ContaBancariaEmpresa? ContaBancariaEmpresa { get; set; }

    }
}