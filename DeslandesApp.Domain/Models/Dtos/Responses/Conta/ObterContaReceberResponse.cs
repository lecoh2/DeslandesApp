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

    public class ObterContaReceberResponse
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataEmissao { get; set; }

        public DateTime DataVencimento { get; set; }

        public string Cliente { get; set; }

        public string? Contrato { get; set; }

        public string? CategoriaFinanceira { get; set; }

        public string? CentroCusto { get; set; }

        public StatusConta Status { get; set; }

        public decimal ValorPago { get; set; }

        // ============================
        // BAIXA FINANCEIRA
        // ============================

        public decimal ValorRecebido { get; set; }

        public bool Quitado { get; set; }

        public DateTime? DataQuitacao { get; set; }

        public ICollection<ContaReceberBaixaResponse> Baixas { get; set; }
       = new List<ContaReceberBaixaResponse>();
        // ============================
        // PARCELAMENTO
        // ============================

        public bool Parcelado { get; set; }

        public int NumeroParcela { get; set; }

        public int TotalParcelas { get; set; }

        public ICollection<ParcelaContaReceberResponse> Parcelas { get; set; }
          = new List<ParcelaContaReceberResponse>();

        // ============================
        // RELACIONAMENTOS
        // ============================

        public Guid? PessoaId { get; set; }

        public Guid? ContratoId { get; set; }

        public Guid? CategoriaFinanceiraId { get; set; }

        public Guid? CentroCustoId { get; set; }

        public TipoContaReceber TipoConta { get; set; }

        public FormaRecebimento FormaRecebimento { get; set; }
    }
}

