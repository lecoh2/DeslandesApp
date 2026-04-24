using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IQueryService<TResponse, TKey>
    {

        Task<TResponse?> ObterPorIdAsync(TKey id);
    }
}
