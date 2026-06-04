using DeslandesApp.Domain.Models.Dtos.Responses.CategoriaFinanceira;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface ICategoriaFinanceiraRepository : IBaseRepository<CategoriaFinanceira, Guid>
    {
        Task<PageResult<CategoriaFinanceiraPaginacaoResponse>> ConsultarCategoriaFinanceiraPaginacaoAsync(
int pageNumber,
int pageSize,
string? searchTerm = null);
        Task<List<CategoriaFinanceiraResponse>> ConsultarCategoriaFinanceiraAsync();
        Task<CategoriaFinanceira?> ObterCompletoPorIdAsync(Guid id);
    }
}
