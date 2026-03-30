using DeslandesApp.Domain.Models.Dtos.Requests.GrupoClienteProceso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiquetaProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoClienteProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaAtendimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IGrupoEtiquetaAtendimentoServices : IBaseService<GrupoEtiquetaAtendimentoRequest, GrupoEtiquetaAtendimentoUpdateRequest, GrupoEtiquetaAtendimentoResponse, Guid>
    {
        Task<GrupoEtiquetaAtendimentoResponse> AdicionarEtiquetaAtendimentoAsync(Guid idEtiqueta, Guid idAtendimento);
        Task<GrupoEtiquetaAtendimentoResponse> RemoverEtiquetaAtendimentoAsync(Guid idEtiqueta, Guid idAtendimento);
    }
}

