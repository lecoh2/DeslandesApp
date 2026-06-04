using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Contrato : BaseEntity
    {
        public string Numero { get; set; }

        // CLIENTE = PESSOA (FISICA OU JURIDICA)
        public Guid PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public string? Objeto { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public decimal? ValorTotal { get; set; }

        public StatusContrato Status { get; set; }

        // RELAÇÃO FINANCEIRA
        public ICollection<ContaReceber> ContasReceber { get; set; } = new List<ContaReceber>();
        public ICollection<ContratoProcesso> ContratoProcessos { get; set; }
            = new List<ContratoProcesso>();
        public string? Observacao { get; set; }

    }
}

