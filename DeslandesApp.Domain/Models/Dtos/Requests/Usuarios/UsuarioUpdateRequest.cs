using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Usuarios
{
    public record UsuarioUpdateRequest
        (
       // Guid IdUsuario,
       string NomeUsuario,
        string Login,
        string Senha,
        DateTime DataAtualizacao,
       // Status? Status,
        string Email
        );
}
