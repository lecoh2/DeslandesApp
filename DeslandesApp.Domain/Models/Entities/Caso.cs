using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Caso
    {
        #region Relacionamentos
        public Pasta? Pasta { get; set; }   
        public ICollection<Pessoa> Pessoas { get; set; }
        public ICollection<GrupoEnvolvidos> Envolvidos { get; set; }

        #endregion

    }
}
