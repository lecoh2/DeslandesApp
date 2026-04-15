using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Vara
{
    public record ConsultarVaraResponse
    {
        public Guid Id { get; set; }
        public string NomeVara { get; set; }
        public Guid ForoId { get; set; }
        public string NomeForo { get; set; } // 👈 ESSENCIAL
    }
}
