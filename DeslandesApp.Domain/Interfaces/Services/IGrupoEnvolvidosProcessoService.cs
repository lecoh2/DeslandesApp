using DeslandesApp.Domain.Models.Dtos.Requests.GrupoClienteProceso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEnvolvidosProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoClienteProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEnvolvidosProcesso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IGrupoEnvolvidosProcessoService : IBaseService<GrupoEnvolvidosProcessoRequest, GrupoEnvolvidosProcessoUpdateRequest, GrupoEnvolvidosProcessoResponse, Guid>
    {
        Task RemoverEnvolvidosProcessoAsync(Guid idPessoa, Guid idProcesso);
        Task AdicionarEnvolvidosProcessoAsync(Guid idPessoa, Guid idProcesso);
    }
}
