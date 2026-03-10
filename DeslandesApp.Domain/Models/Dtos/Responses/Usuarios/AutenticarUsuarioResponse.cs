using DeslandesApp.Domain.Models.Dtos.Responses.Nivel;
using DeslandesApp.Domain.Models.Dtos.Responses.Setor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Usuarios
{
    public record AutenticarUsuarioResponse
    (
     Guid? IdUsuario,
     string Login,
     List<NivelResponse> Nivel,
     List<SetorResponse>Setores,
     DateTime DataHoraAcesso ,
     DateTime DataHoraExpiracao,
     string AccessToken,
     string NomeUsuario ,    
     string Foto ,
     string? IpAcesso 
        );
}
