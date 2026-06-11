using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Conta
{
    public class ContaReceberFiltroRequest
    {
        public string? Search { get; set; }

        public Guid? ClienteId { get; set; }

        public StatusConta? Status { get; set; }

        public FormaRecebimento? FormaRecebimento { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public decimal? ValorMin { get; set; }

        public decimal? ValorMax { get; set; }
    }
}
