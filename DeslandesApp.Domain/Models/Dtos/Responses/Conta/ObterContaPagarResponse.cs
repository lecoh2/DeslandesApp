using DeslandesApp.Domain.Models.Dtos.Responses.BaixaFinanceira;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Conta
{
    public class ObterContaPagarResponse
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public decimal ValorPago { get; set; }

        public DateTime DataVencimento { get; set; }

        public StatusConta Status { get; set; }

        public Guid PessoaId { get; set; }

        public string NomePessoa { get; set; }

        public Guid? CategoriaFinanceiraId { get; set; }

        public string? CategoriaFinanceira { get; set; }
        public ICollection<BaixaFinanceiraResponse> Baixas { get; set; }

        public ICollection<ParcelaContaPagarResponse> Parcelas { get; set; }

        public bool Parcelado { get; set; }

        public int NumeroParcela { get; set; }

        public int TotalParcelas { get; set; }

        public FormaRecebimento FormaRecebimento { get; set; }
    }
}
