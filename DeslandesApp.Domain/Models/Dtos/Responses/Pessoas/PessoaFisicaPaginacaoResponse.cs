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
    public record PessoaFisicaPaginacaoResponse
   (
    Guid? Id,
    int? Perfil,
    string? Nome,
    string? CPF,
    string? RG,
    string? Email,
    string? Telefone
   );

}
