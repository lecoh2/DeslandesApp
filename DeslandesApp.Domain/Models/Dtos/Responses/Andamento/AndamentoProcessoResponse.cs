using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Andamento
{
    public class AndamentoProcessoResponse
    {
        public Guid Id { get; set; }

        public DateTime DataMovimentacao { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public string? Complemento { get; set; }

        public string? Origem { get; set; }

        public bool CapturadoAutomaticamente { get; set; }
    }
}
