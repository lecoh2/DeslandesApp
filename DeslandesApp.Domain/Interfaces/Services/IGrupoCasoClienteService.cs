using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoClienteProcesso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IGrupoCasoClienteService : IBaseService<GrupoCasoClienteRequest, GrupoCasoClienteUpdateRequest, GrupoCasoClienteResponse, Guid>
    {
        Task<GrupoCasoClienteResponse> RemoverGrupoCasoClienteAsync(Guid idPessoa, Guid idCaso);
    Task<GrupoCasoClienteResponse> AdicionarGrupoCasoClienteAsync(Guid idPessoa, Guid idCaso);
}
}
  