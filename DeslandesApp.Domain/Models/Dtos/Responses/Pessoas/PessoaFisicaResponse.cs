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
         string Site,
         DateTime DataCadastro,
         DateTime DataAtualizacao,
         Guid IdUsuarioCadastro,
         Guid IdSexo,
         Guid IdEtiqueta,
         Guid IdPessoa,
    #region Relacionamento
         EnderecoResponse Endereco,
         InformacoesComplementaresResponse InformacoesComplementares,
         //SexoRequest Sexo,
    // Usuario Usuario,
    // Usuario UsuarioCadastro,
          string Email,
  
    #endregion

    #region ENUMERADO STATUS
    Etiqueta Etiqueta,
     Perfil Perfil,
     Telefone TipoTelefone,
     TipoConta TipoEmail

    #endregion

    );

}
