using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Tafefa
    {
        public string NomeTarefa { get; set; } = string.Empty;
        public DateOnly DataTarefa { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        #region Relacionamentos
        public Recorencia? RecorenciaTarefa { get; set; } 
        #endregion
    }
}
