using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Conta
{

    public class ContaReceberConsultaResponse
    {
        public Guid Id { get; set; }

        public string Cliente { get; set; }

        public string Descricao { get; set; }

        public string NumeroContrato { get; set; }

        public decimal ValorTotal { get; set; }

        public bool Parcelado { get; set; }

        public int TotalParcelas { get; set; }
        public FormaRecebimento FormaRecebimento { get; set; }
        public StatusConta Status { get; set; }
        public string StatusDescricao { get; set; }
    }
}
    
