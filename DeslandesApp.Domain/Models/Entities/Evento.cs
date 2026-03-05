using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Evento
    {
        public string NomeEvento { get; set; }
        public DateOnly DataInicioEvento { get; set; }
        public TimeSpan HoraInicioEvento { get; set; }
        public DateOnly DataFimEvento { get; set; }
        public TimeSpan HoraFimEvento { get; set; }
        public string? Local { get; set; }
        public string? Observacao   { get; set; }

        #region Enumerações
        public Dia? Dia { get; set; }
        public Modalidade? Modalidade { get; set; }
        public AlertaDias? AlertaDias { get; set; }
        #endregion

        #region Relacionamentos
        public Recorencia? RecorenciaEvento { get; set; }
        public Processo? Processo { get; set; }
        public Alerta? Alerta { get; set; } 
        public ICollection<Usuario> Usuario { get; set; }
        //Caso ou evento

        #endregion

    }
}
