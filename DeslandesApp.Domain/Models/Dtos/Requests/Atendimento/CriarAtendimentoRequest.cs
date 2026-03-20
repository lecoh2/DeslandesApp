using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Atendimento
{
    public record CriarAtendimentoRequest
    {
        public string Assunto { get; init; } = string.Empty;
        public string Registro { get; init; } = string.Empty;
        public Etiquetas Etiqueta { get; init; } 
        public Guid? ProcessoId { get; init; }
        public List<Guid> ClientesIds { get; init; } = new List<Guid>();
    }
}
