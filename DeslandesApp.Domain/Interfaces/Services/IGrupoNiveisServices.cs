using DeslandesApp.Domain.Models.Dtos.Requests.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Requests.Nivel;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Responses.Nivel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IGrupoNiveisServices : IBaseService<GrupoNivelRequest, GrupoNivelUpdateRequest, GrupoNivelResponse, Guid>
    {
        Task AdicionarNivelAsync(Guid idUsuario, Guid idNivel);
        Task RemoverNivelAsync(Guid idUsuario, Guid idNivel);
    }
}

