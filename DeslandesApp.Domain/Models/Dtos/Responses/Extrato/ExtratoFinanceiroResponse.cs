using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Extrato
{
    public class ExtratoFinanceiroResponse
    {
        public Guid PessoaId { get; set; }
        public string NomePessoa { get; set; }

        public decimal TotalReceber { get; set; }
        public decimal TotalRecebido { get; set; }

        public decimal TotalPagar { get; set; }
        public decimal TotalPago { get; set; }

        public decimal Saldo => (TotalRecebido - TotalPago);
    }
}
