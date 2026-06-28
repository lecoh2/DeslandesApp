using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IMonitoramentoProcessualService
    {
        Task AtualizarProcessoAsync(Guid processoId);

        Task AtualizarTodosProcessosAsync();
    }
}
