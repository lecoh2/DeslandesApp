using DeslandesApp.Domain.Models.Dtos.Requests.CategoriaFinanceira;
using DeslandesApp.Domain.Models.Dtos.Responses.CategoriaFinanceira;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface ICategoriaFinanceiraService : IBaseService<CategoriaFinanceiraRequest, CategoriaFinanceiraUpdateRequest, CategoriaFinanceiraResponse, Guid>
    {
        Task<PageResult<CategoriaFinanceiraPaginacaoResponse>> ConsultarCategoriaFinanceiraPaginacaoAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm = null);
        Task<ObterCategoriaFinanceiraResponse?>
           ObterPorIdAsync(Guid id);

    }
}
