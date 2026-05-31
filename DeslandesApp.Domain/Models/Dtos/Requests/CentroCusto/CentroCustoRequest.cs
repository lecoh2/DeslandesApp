using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.CentroCusto
{
    public class CentroCustoRequest
    {
        public string Nome { get; set; }

        public string? Descricao { get; set; }
    }
}
