using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class GrupoCasoEnvolvido : BaseEntity
    {
        public Guid CasoId { get; set; }
        public Caso Caso { get; set; } = null!;

        public Guid PessoaId { get; set; }
        public Pessoa Pessoa { get; set; } = null!;

        public Guid? QualificacaoId { get; set; }
        public Qualificacao? Qualificacao { get; set; }
    }
}
