using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class EnvolvidoTemp
    {
        public Guid CasoId { get; set; }
        public Guid PessoaId { get; set; }
        public Guid? QualificacaoId { get; set; }
        public string Nome { get; set; }
        public string NomeQualificacao { get; set; }
    }
}
