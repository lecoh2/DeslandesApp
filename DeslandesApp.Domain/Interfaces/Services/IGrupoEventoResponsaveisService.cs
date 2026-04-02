using DeslandesApp.Domain.Models.Dtos.Requests;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEventoResponsavel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IGrupoEventoResponsaveisService : IBaseService<GrupoEventoResponsavelRequest, GrupoEventoResponsavelUpdateRequest, GrupoEventoResponsavelResponse, Guid>
    {
        Task<GrupoEventoResponsavelResponse> RemoverGrupoEventoResponsaveisAsync(Guid idEvento, Guid idUsuario);
        Task<GrupoEventoResponsavelResponse> AdicionarEventoResponsaveisAsync(Guid idEvento, Guid idUsuario);
    }
}
