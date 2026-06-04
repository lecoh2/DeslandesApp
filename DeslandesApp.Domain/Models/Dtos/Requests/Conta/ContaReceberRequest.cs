using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Conta
{
    public class ContaReceberRequest
    {
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }

        public Guid PessoaId { get; set; }

        public Guid? ContratoId { get; set; }

        public Guid? CategoriaFinanceiraId { get; set; }

        public Guid? CentroCustoId { get; set; }
    }
}
