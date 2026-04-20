using DeslandesApp.Domain.Models.Dtos.Requests.Etiquetas;
using DeslandesApp.Domain.Models.Dtos.Responses.Etiquetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IEtiquetasService : IBaseService<EtiquetasRequest,EtiquetasUpdateRequest, EtiquetaResponse, Guid>
    {
         Task<IEnumerable<EtiquetaResponse>> ConsultarAsync();
    }
}
