using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Endereco
{
    public record EnderecoResponse
    (
         string? Logradouro,
         string? Numero,
         string? Complemento,
         string? Bairro,
         string? Localidade,
         string? Uf,
         string? Cep
    );
}
