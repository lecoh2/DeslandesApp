using DeslandesApp.Domain.Models.Dtos.Requests.GrupoClienteProceso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoSetores;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoClienteProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoSetores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IGrupoClienteProcessoService : IBaseService<GrupoClienteProcessoRequest, GrupoClienteProcessoUpdateRequest, GrupoClienteProcessoResponse, Guid>
    {
        Task <GrupoClienteProcessoResponse>RemoverClienteProcessoAsync(Guid idPessoa, Guid idProcesso);
        Task<GrupoClienteProcessoResponse>AdicionarClienteProcessoAsync(Guid idPessoa, Guid idProcesso);
    }
}
