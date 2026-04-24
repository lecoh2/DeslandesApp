using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoTarefaResponsaveis
{
    public class TarefaResponsavelResponse
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
    }
}
