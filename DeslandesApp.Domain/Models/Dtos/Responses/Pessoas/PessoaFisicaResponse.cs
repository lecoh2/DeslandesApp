using DeslandesApp.Domain.Models.Dtos.Requests.Sexo;
using DeslandesApp.Domain.Models.Dtos.Responses.EnderecoEndereco;
using DeslandesApp.Domain.Models.Dtos.Responses.InformacoesComplementares;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Pessoas
{
  
     public record PessoaFisicaResponse
(
    Guid Id,
    string Nome,
    string Apelido,
    string Telefone,
    string Email,
    DateTime DataCadastro,
    EnderecoResponse Endereco,
    InformacoesComplementaresResponse InformacoesComplementares
);

}
