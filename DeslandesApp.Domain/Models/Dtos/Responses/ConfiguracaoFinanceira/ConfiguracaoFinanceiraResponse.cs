using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.ConfiguracaoFinanceira
{
    public class ConfiguracaoFinanceiraResponse
    {
        public Guid Id { get; set; }

        public decimal MetaMensal { get; set; }

        public decimal MetaAnual { get; set; }
    }
}
