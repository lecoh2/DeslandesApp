using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.GrupoAtendimento
{
    public record GrupoAtendimentoClienteRequest
    {
        public Guid? PessoaId { get; init; }
      //  public Guid? AtendimentoId  { get; init; }
 
    }
}
