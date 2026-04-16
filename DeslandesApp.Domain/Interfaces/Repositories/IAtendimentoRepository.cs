using DeslandesApp.Domain.Models.Dtos.Responses.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IAtendimentoRepository : IBaseRepository<Atendimento, Guid>
    {
        Task<PageResult<AtendimentoPaginacaoResponse>> GetAtendimentoPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null);
        Task<Atendimento> ConsultarAtendimentoComRelacionamentosAsync(Guid idAtendimento);
        Task<List<AtendimentoAutoComplete>> ConsultarAtendimentoAutoCompleteAsync(string? termo = null);
    }
}
