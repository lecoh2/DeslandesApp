using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.CategoriaFinanceira
{
    public class CategoriaFinanceiraPaginacaoResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public TipoCategoriaFinanceira Tipo { get; set; }
    }
}
