using DeslandesApp.Domain.Models.Dtos.Responses.Nivel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Usuarios
{
    public class AutenticarUsuarioResponse
    (
          Guid? IdUsuario,
     string Login,
     List<NivelResponse> Nivel,
     DateTime DataHoraAcesso ,
     DateTime DataHoraExpiracao,
     string AccessToken,
     string NomeUsuario ,
     string Sexo, 
     string Foto ,
     string? IpAcesso 
        );
}
