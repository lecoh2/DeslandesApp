using DeslandesApp.Domain.Models.Dtos.Responses.DashboardFinanceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IDashboardFinanceiroService
    {
        Task<DashboardFinanceiroResponse>ObterDashboardAsync();

      
        Task<DashboardFinanceiroResponse>
    ObterDashboardAsync(
        int? ano = null,
        int? mes = null);
    }
}
