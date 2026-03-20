using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Tarefa
{
    public record CriarTarefaRequest
    {
        public string Descricao { get; init; } = string.Empty;
        public DateTime DataTarefa { get; init; } = DateTime.Now;

        // Lista de listas de tarefas vinculadas
        public List<CriarListaTarefaRequest> ListasTarefa { get; init; } = new List<CriarListaTarefaRequest>();
    }
}
