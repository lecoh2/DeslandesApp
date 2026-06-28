using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.DashboardFinanceiro
{
    public class MovimentacaoFinanceiraResponse
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public string Pessoa { get; set; } = string.Empty;

        public decimal Valor { get; set; }

        public string Tipo { get; set; } = string.Empty;
        // Recebimento ou Pagamento

        public StatusConta Status { get; set; }
    }
}
