using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{


    public class AndamentoProcesso : BaseEntity
    {
        public Guid ProcessoId { get; set; }
        public Processo Processo { get; set; } = null!;

        public DateTime DataMovimentacao { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public string? Complemento { get; set; }

        public string? Origem { get; set; }

        public bool CapturadoAutomaticamente { get; set; }


    }
}
