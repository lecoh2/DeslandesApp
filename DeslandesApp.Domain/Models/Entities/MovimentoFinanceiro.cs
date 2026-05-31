using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class MovimentoFinanceiro : BaseEntity
    {
        public DateTime DataMovimento { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public TipoMovimentoFinanceiro Tipo { get; set; }

        // CONTA BANCÁRIA
        public Guid? ContaBancariaEmpresaId { get; set; }

        public ContaBancariaEmpresa? ContaBancariaEmpresa { get; set; }

        // ORIGENS
        public Guid? ContaReceberId { get; set; }

        public ContaReceber? ContaReceber { get; set; }

        public Guid? ContaPagarId { get; set; }

        public ContaPagar? ContaPagar { get; set; }

        // CATEGORIA
        public Guid? CategoriaFinanceiraId { get; set; }

        public CategoriaFinanceira? CategoriaFinanceira { get; set; }

        // CENTRO DE CUSTO
        public Guid? CentroCustoId { get; set; }

        public CentroCusto? CentroCusto { get; set; }
    }
}
