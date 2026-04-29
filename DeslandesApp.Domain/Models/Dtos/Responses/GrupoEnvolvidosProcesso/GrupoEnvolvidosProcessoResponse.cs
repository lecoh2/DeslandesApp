using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoEnvolvidosProcesso
{
    public record GrupoEnvolvidosProcessoResponse
    {
        public Guid IdPessoa      { get; init; }
        public Guid IdProcesso     { get; init; }
       public string Nome     { get; init; } 
        public Guid QualificacaoId { get; init; }
        public string NomeQualificacao { get; init; } 
    }
}
