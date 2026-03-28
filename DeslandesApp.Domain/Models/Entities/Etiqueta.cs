using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Etiqueta : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;

        public List<TarefaEtiqueta> TarefaEtiquetas { get; set; } = new();
        public List<ProcessoEtiqueta> ProcessoEtiquetas { get; set; } = new();
    }
}
