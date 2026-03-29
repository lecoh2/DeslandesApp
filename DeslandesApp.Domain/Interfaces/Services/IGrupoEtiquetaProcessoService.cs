using DeslandesApp.Domain.Models.Dtos.Requests.GrupoClienteProceso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiquetaProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoClienteProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetasProcessos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IGrupoEtiquetaProcessoService : IBaseService<GrupoEtiquetaProcessoRequest, GrupoEtiquetaProcessoUpdateRequest, GrupoEtiquetasProcessosResponse, Guid>
    {
        Task RemoverEtiquetaProcessoAsync(Guid idEtiqueta, Guid idProcesso);
        Task AdicionarEtiquetaProcessoAsync(Guid idEtiqueta, Guid idProcesso);
    }
}
