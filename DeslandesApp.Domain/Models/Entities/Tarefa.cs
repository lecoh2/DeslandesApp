using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Tarefa : BaseEntity
    {
        public string? Descricao { get; set; } = string.Empty;
        public DateTime? DataTarefa { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        // Lista de tarefas vinculadas ao processo
        public List<ListaTarefa>? ListasTarefa { get; set; } = new List<ListaTarefa>();
    }
}
