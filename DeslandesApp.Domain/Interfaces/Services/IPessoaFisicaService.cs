
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Vara;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IPessoaFisicaService : IBaseService<PessoaFisicaRequest, PessoaFisicaUpdateRequest, PessoaFisicaResponse, Guid>
    {
        Task<PageResult<PessoaFisicaPaginacaoResponse>> ConsultarPessoaFisicaPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null);
      
    }
}
