using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Atendimento
{
    public class AtendimentoAutoComplete
    {
        public Guid? Id { get; set; }
        public string Assunto { get; init; }
    }
}
