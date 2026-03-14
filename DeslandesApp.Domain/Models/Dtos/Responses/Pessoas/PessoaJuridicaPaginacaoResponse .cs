using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Pessoas
{
    public record PessoaJuridicaPaginacaoResponse
   (
    Guid? Id,
    string? Nome,
    string? Cnpj,
    string? IncricaoEstadual,
    string? Email,
    string? Telefone
   );

}
