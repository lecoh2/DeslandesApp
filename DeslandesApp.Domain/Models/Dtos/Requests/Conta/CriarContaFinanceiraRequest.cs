using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Conta
{
    public record CriarContaFinanceiraRequest
    {
        public TipoContaFinanceira Tipo { get; init; }

        public decimal Valor { get; init; }

        public DateTime DataVencimento { get; init; }

        public string Descricao { get; init; }

        public Guid ClienteId { get; init; }

        public VinculoFinanceiroRequest? Vinculo { get; init; }
    }

    public record VinculoFinanceiroRequest
    {
        public Guid? ProcessoId { get; init; }
        public Guid? CasoId { get; init; }
        public Guid? AtendimentoId { get; init; }
    }
}
