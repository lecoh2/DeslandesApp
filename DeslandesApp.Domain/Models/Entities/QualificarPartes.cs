using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class QualificarPartes
    {
        public string NomeQualificacaoParte { get; set; }
        public Polo? Polo { get; set; }
    }
}
