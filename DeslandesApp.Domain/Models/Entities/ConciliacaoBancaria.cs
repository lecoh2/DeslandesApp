using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class ConciliacaoBancaria : BaseEntity
    {
        public DateTime DataMovimentoBanco { get; set; }

        public string DescricaoBanco { get; set; }

        public decimal ValorBanco { get; set; }

        public bool Conciliado { get; set; }

        public Guid? MovimentoFinanceiroId { get; set; }

        public MovimentoFinanceiro? MovimentoFinanceiro { get; set; }
    }
}
