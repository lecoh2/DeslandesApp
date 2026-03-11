using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.EnderecoEndereco
{
    public record EnderecoResponse
   (
        Guid IdEndereco,
     string? Logradouro,
     string? Numero,
     string? Complemento,
     string? Bairro,
     string? Cep,
     string? Localidade,
     string? Uf,
     Guid? IdPessoa
        );
}
