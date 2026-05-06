using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class AtendimentoAgrupado
    {
        public int Mes { get; set; }
        public TipoVinculo? TipoVinculo { get; set; }
        public int Quantidade { get; set; }
        public string TipoDescricao { get; set; } = string.Empty;
    }
}
