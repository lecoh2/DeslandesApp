using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class ContaBancaria
    {
      
            public int Id { get; set; } // Id único da conta
            public string NomeBanco { get; set; } = string.Empty;
            public string Agencia { get; set; } = string.Empty;
            public string NumeroConta { get; set; } = string.Empty;
            public string Pix { get; set; } = string.Empty;

            // Relacionamento
            public Guid PessoaId { get; set; }
            public Pessoa Pessoa { get; set; } = null!;

            public int? TipoContaId { get; set; }
        public TipoConta? TipoConta { get; set; }
    }
    }

