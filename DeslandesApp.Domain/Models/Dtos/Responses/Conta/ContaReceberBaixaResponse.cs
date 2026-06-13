using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Conta
{
    public class ContaReceberBaixaResponse
    {
        public Guid Id { get; set; }

        public decimal ValorPago { get; set; }

        public DateTime DataBaixa { get; set; }

        public FormaRecebimento FormaRecebimento { get; set; }

        public string? Observacao { get; set; }
    }
}
