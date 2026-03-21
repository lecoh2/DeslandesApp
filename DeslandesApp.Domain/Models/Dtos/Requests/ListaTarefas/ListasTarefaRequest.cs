using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.ListaTarefas
{
    public record ListasTarefaRequest
    {
        public string Descricao { get; set; } = string.Empty;

        public bool Concluida { get; set; } = false;

        public DateTime? DataConclusao { get; set; }

        public int Ordem { get; set; }
    }
}
