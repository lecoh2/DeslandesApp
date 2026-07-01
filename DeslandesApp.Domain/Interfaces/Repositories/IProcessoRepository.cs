using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.WebJur;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IProcessoRepository : IBaseRepository<Processo, Guid>
    {
        Task<PageResult<ProcessoPaginacaoResponse>> GetProcessoPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null);
        Task<Processo> ConsultarProcessoComRelacionamentosAsync(Guid idPessoa);
        Task<List<ProcessoAutoComplete>> ConsultarProcessoAutoCompleteAsync(string? termo = null);
        Task<Processo?> ObterCompletoPorIdAsync(Guid id);
        Task<List<ProcessoResumoResponse>> ConsultarUltimosAsync(int quantidade);
        Task<List<ProcessoAgrupado>> GetGraficoProcessoAsync();
        Task<int> ContarProcessoAnoAtual();
        Task<int> ContarTotal();
        Task<List<Processo>> ObterMonitoradosAsync();

        Task<Processo?> ObterPorIdAsync(Guid id);

        Task<List<Processo>> ObterTodosAsync();
        Task<Processo?> ObterPorNumeroAsync(string numeroProcesso);
        Task<ProcessoWebJurResumoResponse?> ObterResumoProcessoAsync(Guid id);



    }
}
