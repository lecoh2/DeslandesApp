using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEnvolvidosProcesso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoTarefasEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoTarefasResponsaveis;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEnvolvidosProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoTarefaResponsaveis;
using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public  interface IGrupoTarefaResponsaveisService : IBaseService<GrupoTarefaResponsaveisRequest, GrupoTarefaResponsaveisUpdateRequest, GrupoTarefaResponsaveisResponse, Guid>
    {
        Task<GrupoTarefaResponsaveisResponse> RemoverTarefaResponsaveisAsync(Guid idPessoa, Guid idTarefa);
        Task<GrupoTarefaResponsaveisResponse> AdicionarTarefaResponaveisAsync(Guid idPessoa, Guid idTarefa);
    }
}
