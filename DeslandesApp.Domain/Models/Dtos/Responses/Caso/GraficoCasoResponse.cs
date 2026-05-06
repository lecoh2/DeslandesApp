using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Caso
{
    public record GraficoCasoResponse
    {
        public int Mes { get; set; }
        public int Quantidade { get; set; }
    }
}
