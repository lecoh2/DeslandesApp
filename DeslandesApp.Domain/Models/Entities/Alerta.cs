using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Alerta
    {
        public int AletaAntecendencia { get; set; }
        public AlertaDias? AlertaDias{ get; set; }
    }
}
