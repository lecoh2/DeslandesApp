using DeslandesApp.Domain.Models.Dtos.Requests.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoSetores;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Usuarios
{
    public record UsuariosRequest(

    string NomeUsuario,
    string Login,
    string Senha,
    DateTime DataCadastro,

    Status? Status,
    string Email,
    List<GrupoSetorRequest> GrupoSetor,
    List<GrupoNivelRequest> GrupoNivel
);

}
