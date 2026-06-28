using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Contrato
{
    public class ContratoUpdateRequest
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }

        public Guid PessoaId { get; set; }


        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }
        public StatusContrato Status { get; set; }
        public List<Guid> ProcessosIds { get; set; }
        public string? Observacao { get; set; }
    }
}
