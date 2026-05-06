using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Atendimento
{
    public record GraficoAtendimentoResponse
    {
        public int Mes { get; set; }
        public TipoVinculo? TipoVinculo { get; set; } // forte
        public string Tipo { get; set; } = "";        // amigável
        public int Quantidade { get; set; }
    }
}
