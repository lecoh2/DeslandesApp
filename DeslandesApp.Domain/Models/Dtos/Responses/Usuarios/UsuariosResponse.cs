using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Usuarios
{
    public record UsuariosResponse(
        Guid Id,
        string NomeUsuario,
        string Login,
        string Senha,
        DateTime DataCadastro,
        Guid IdPessoa,
        PessoaFisica Pessoa,
        Status? Status,
        ICollection<GrupoSetores> GrupoSetores,
        ICollection<GrupoNiveis> GrupoNiveis,
        Fotos Fotos,
        ValorEmail ValorEmail
        );


}
