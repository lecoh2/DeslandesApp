using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.EnderecoPessoa
{
    public record EnderecoUpdateRequest
    (
                 Guid IdEndereco,
     string? Logradouro,
     string? Numero,
     string? Complemento,
     string? Bairro,
     string? Cep,
     string? Localidade,
     string? Uf,
     Guid? IdPessoa);
}
