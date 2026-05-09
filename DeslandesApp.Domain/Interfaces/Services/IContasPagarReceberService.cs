using DeslandesApp.Domain.Models.Dtos.Requests.Conta;
using DeslandesApp.Domain.Models.Dtos.Requests.Vara;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.Vara;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IContasPagarReceberService : IBaseService<CriarContaFinanceiraRequest, CriarContaFinanceiraUpdateRequest, CriarContaFinanceiraResponse, Guid>
    {
        Task<Guid> CriarAsync(CriarContaFinanceiraRequest request);
        Task BaixarPagamentoAsync(Guid id, decimal valorPago);
    }
}
