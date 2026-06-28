using DeslandesApp.Domain.Models.Dtos.Responses.contrato_processo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Contrato
{
    public class ContratoResponse
    {
        public Guid Id { get; set; }

        public string Numero { get; set; }

        public Guid PessoaId { get; set; }

        public string NomePessoa { get; set; }


        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }
        public List<ContratoProcessoResponse> Processos { get; set; }
    }
}
