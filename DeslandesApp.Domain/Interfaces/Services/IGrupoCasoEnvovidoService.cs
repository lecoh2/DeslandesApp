using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoEnvolvidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IGrupoCasoEnvovidoService : IBaseService<GrupoCasoEnvolvidosRequest, GrupoCasoEnvolvidoUpdateRequest, GrupoCasoEnvolvidosResponse, Guid>
    {
        Task<GrupoCasoEnvolvidosResponse> RemoverGrupoCasoEnvolvidoAsync(Guid idPessoa, Guid idCaso);
        Task<GrupoCasoEnvolvidosResponse> AdicionarGrupoCasoEnvolvidoAsync(Guid idPessoa, Guid idCaso);
    }
}
