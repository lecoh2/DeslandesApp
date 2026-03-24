using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class KanbanColuna
    {
        public StatusGeralKanban Status { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<KanbanCard> Cards { get; set; } = new();
    }
}
