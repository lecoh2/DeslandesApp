using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiquetaCaso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiquetaProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaAtendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaCaso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IGrupoEtiquetaCasoService : IBaseService<GrupoEtiquetaCasoRequest, GrupoEtiquetaCasoUpdateRequest, GrupoEtiquetaCasoResponse, Guid>
    {
        Task<GrupoEtiquetaCasoResponse> AdicionarEtiquetaCasoAsync(Guid idEtiqueta, Guid idCaso);
        Task<GrupoEtiquetaCasoResponse> RemoverEtiquetaCasoAsync(Guid idEtiqueta, Guid idCaso);
    }
}