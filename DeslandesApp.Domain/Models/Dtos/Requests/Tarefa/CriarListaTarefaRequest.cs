using DeslandesApp.Domain.Models.Dtos.Requests.GrupoTarefasEnvolvidos;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Tarefa
{
    public record CriarListaTarefaRequest
    {
        public string Descricao { get; init; } = string.Empty;

        //public int? Ordem { get; init; }
        public bool Concluida { get; init; } = false;
        public DateTime? DataConclusao { get; init; }
    }
}

