using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.ListaTarefas
{
    public record ReordenarListaTarefaRequest
    {
        public Guid Id { get; init; }
        public int Ordem { get; init; }
    }
}
