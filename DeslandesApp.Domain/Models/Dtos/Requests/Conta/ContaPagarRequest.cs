using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Conta
{
    public class ContaPagarRequest
    {
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }

        public Guid PessoaId { get; set; }

        public Guid? CategoriaFinanceiraId { get; set; }

        public Guid? ContratoId { get; set; } // ✔ ADICIONADO
        public bool Parcelado { get; set; }

        public Guid? ContaPaiId { get; set; }

        public int NumeroParcela { get; set; }

        public int TotalParcelas { get; set; }
        // =========================
        // PARCELAMENTO
        // =========================


        public int? QuantidadeParcelas { get; set; }
    }
}
