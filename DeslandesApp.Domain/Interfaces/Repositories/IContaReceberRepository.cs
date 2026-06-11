using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IContaReceberRepository : IBaseRepository<ContaReceber, Guid>
    {

        Task<PageResult<ContaReceberConsultaResponse>> GetPaginacaoAsync(
           int pageNumber,
           int pageSize,
           string? searchTerm = null);

        Task<List<ContaReceber>> ConsultarComRelacionamentosAsync();

        Task<ContaReceber?> ObterCompletoPorIdAsync(Guid id);

        Task<List<ContaReceber>> ConsultarUltimasAsync(int quantidade);

        Task<int> ContarTotalAsync();

        Task<int> ContarAnoAtualAsync();
        Task AtualizarContaPaiAsync(
    Guid contaPaiId,
    decimal valorPago,
    decimal valorRecebido,
    StatusConta status,
    bool quitado,
    DateTime? dataQuitacao);
        Task<bool> ExistePorContratoAsync(Guid contratoId);
        Task<bool> ExisteContaPrincipalPorContratoAsync(
    Guid contratoId);
        Task<bool> ExisteDuplicidadeAsync(
    Guid contratoId,
    string descricao,
    decimal valor,
    DateTime dataVencimento);

    }
}