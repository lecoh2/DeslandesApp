using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Atendimento
    {
        public string Assunto { get; set; } = string.Empty;
        public string RegistroAtendimento { get; set; } = string.Empty;
        #region Relacionamentos
        public ICollection<Pessoa> Pessoas { get; set; }
        public Processo? Processo { get; set; }
        public ListaTarefas     ? ListaTarefas { get; set; }
        public ICollection<GrupoEnvolvidos> Envolvidos { get; set; }

        //Observção: Verificar os relacionamentos pode ser casa ou atendimento
        #endregion
        #region Enumerações
        public Etiqueta? Etiqueta { get; set; }
        public Prioridade?  Prioridade { get; set; }

        #endregion
    }
}

