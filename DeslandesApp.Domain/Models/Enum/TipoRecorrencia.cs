using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Enum
{
    public enum TipoRecorrencia
    {
        Nenhuma = 0,
        Diario = 1,
        DiasUteis = 2,        // Segunda a sexta
        Semanal = 3,
        Mensal = 4,
        Anual = 5,
    }
}
