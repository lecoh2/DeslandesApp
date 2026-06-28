using DeslandesApp.Domain.Models.Dtos.Requests.ConfiguracaoFinanceira;
using DeslandesApp.Domain.Models.Dtos.Responses.ConfiguracaoFinanceira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IConfiguracaoFinanceiraService
    {
        Task<ConfiguracaoFinanceiraResponse>
            ObterAsync();

        Task<ConfiguracaoFinanceiraResponse>
            SalvarAsync(
                ConfiguracaoFinanceiraRequest request);
    }
}
