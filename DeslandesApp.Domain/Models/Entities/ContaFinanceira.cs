using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class ContaFinanceira
    {
        public Guid Id { get; set; }

        public TipoContaFinanceira Tipo { get; set; } // Pagar / Receber

        public decimal Valor { get; set; }

        public decimal ValorPago { get; set; }

        public DateTime DataEmissao { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime? DataPagamento { get; set; }

        public StatusContaFinanceira Status { get; set; }

        public string Descricao { get; set; }

        public Guid? ProcessoId { get; set; }
        public Processo Processo { get; set; }

        public Guid? CasoId { get; set; }
        public Caso Caso { get; set; }

        public Guid? AtendimentoId { get; set; }
        public Atendimento Atendimento { get; set; }

        public Guid? ClienteId { get; set; }
        public Pessoa Cliente { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
