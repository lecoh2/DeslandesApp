using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.WebJur
{
    public class WebJurMovimentacaoResponse
    {
        public Guid Id { get; set; }

        public DateTime DataMovimentacao { get; set; }

        public string Tipo { get; set; }

        public string Descricao { get; set; }

        public string Origem { get; set; }
    }
}
