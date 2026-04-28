using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoCliente
{
    public class GrupoCasoClienteResponse
    {
        public Guid PessoaId { get; set; }
        public Guid CasoId { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
