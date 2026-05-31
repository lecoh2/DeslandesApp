using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.CategoriaFinanceira
{
    public class CategoriaFinanceiraRequest
    {
        public string Nome { get; set; }

        public TipoCategoriaFinanceira Tipo { get; set; }
    }
}
