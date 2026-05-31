using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class ContaReceber : BaseEntity
    {
        public Guid ContratoId { get; set; }
        public Contrato Contrato { get; set; } 
        public Guid PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }

        public StatusConta Status { get; set; }

        public DateTime? DataBaixa { get; set; }
        public decimal ValorPago { get; set; }

        public ICollection<BaixaFinanceira> Baixas { get; set; }
        public Guid? CategoriaFinanceiraId { get; set; }

        public CategoriaFinanceira? CategoriaFinanceira { get; set; }
        public Guid? CentroCustoId { get; set; }

        public CentroCusto? CentroCusto { get; set; }
    }
}
