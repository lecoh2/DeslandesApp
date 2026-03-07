using DeslandesApp.Domain.Models.Dtos.Requests.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoSetores;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoSetores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IGrupoSetoresService : IBaseService<GrupoSetorRequest, GrupoSetorResponse, Guid>
    {
    }
}


