using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Usuarios
{
    public record UsuarioResumoResponse(
    Guid Id,
    string NomeUsuario
);
}
