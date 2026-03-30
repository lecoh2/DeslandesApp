using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoAtendimentoCliente
{
    public record GrupoAtendimentoClienteResponse
    {
        public Guid? PessoaId { get; init; }
        public string? Nome { get; init; }
    }
}
