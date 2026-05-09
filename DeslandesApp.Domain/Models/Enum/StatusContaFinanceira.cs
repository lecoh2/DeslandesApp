using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Enum
{
    public enum StatusContaFinanceira
    {
        Aberta = 1,
        Paga = 2,
        Cancelada = 3,
        Vencida = 4,
        ParcialmentePaga = 5
    }
}
