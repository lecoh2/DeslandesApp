using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Conta
{
    public class ContaReceberResponse
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public decimal ValorPago { get; set; }

        public DateTime DataVencimento { get; set; }

        public StatusConta Status { get; set; }

        public Guid PessoaId { get; set; }

        public string NomePessoa { get; set; }

        public Guid? ContratoId { get; set; }

        public string? NumeroContrato { get; set; }

        public Guid? CategoriaFinanceiraId { get; set; }

        public string? CategoriaFinanceira { get; set; }

        public Guid? CentroCustoId { get; set; }

        public string? CentroCusto { get; set; }
        public bool Excluido { get; set; }
    }
}
