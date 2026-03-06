using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IBaseService<TRequest, TResponse, TKey> :IDisposable
    {
        Task<TResponse> AdicionarAsync(TRequest request);

        Task<TResponse> Modificar(TKey id, TRequest request);

        Task<TResponse> Excluir(TKey id);

        Task<PageResult<TResponse>> ConsultarAsync(int pageNumber, int pageSize);

        Task<TResponse?> ObterPorIdAsync(TKey id);
    }
}
