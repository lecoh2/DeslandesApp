using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.ConfiguracaoFinanceira
{
    public class ConfiguracaoFinanceiraRequest
    {
        public decimal MetaMensal { get; set; }

        public decimal MetaAnual { get; set; }
    }
}
