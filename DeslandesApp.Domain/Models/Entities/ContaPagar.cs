using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class ContaPagar : BaseEntity
    {
        public string Descricao { get; set; } = string.Empty;

        public decimal Valor { get; set; }
        public decimal ValorPago { get; set; }

        public DateTime DataVencimento { get; set; }

        public StatusConta Status { get; set; }

        // =========================
        // FORNECEDOR (Pessoa)
        // =========================
        public Guid PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        // =========================
        // OPCIONAL: vínculo com contrato (se fizer sentido)
        // =========================
        public Guid? ContratoId { get; set; }
        public Contrato? Contrato { get; set; }
        public Guid? CategoriaFinanceiraId { get; set; }

        public CategoriaFinanceira? CategoriaFinanceira { get; set; }
        public Guid? CentroCustoId { get; set; }

        public CentroCusto? CentroCusto { get; set; }
    }
}
