using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoEnvolvidos
{
    public class GrupoCasoEnvolvidosResponse
    {
        public Guid PessoaId { get; set; }
        public string? Nome { get; set; }
        public Guid? QualificacaoId { get; set; }
        public string? NomeQualificacao { get; set; }

    }
}
