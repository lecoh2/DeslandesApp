using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoCliente
{
    public record GrupoCasoClienteResponse
  (
       Guid PessoaId,
    string Nome,
    Guid QualificacaoId,
    string NomeQualificacao
  );
}
