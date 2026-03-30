using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoTarefaResponsaveis
{
    public record GrupoTarefaResponsaveisResponse
      (
      Guid idPessoa,
      Guid idTarefa,
      string nome
        );
}
