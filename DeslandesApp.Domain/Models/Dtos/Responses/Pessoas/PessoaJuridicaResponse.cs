using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Pessoas
{
    public record PessoaJuridicaResponse
    (
        Guid Id,
    string Nome,
    string IncricaoEstadual,
    string InscricaoMunicipal,
    string Telefone,
    string Email
        );
    
}
