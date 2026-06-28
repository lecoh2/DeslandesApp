using DeslandesApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/dashboard-financeiro")]
    [ApiController]
    public class DashboardFinanceiroController(
     IDashboardFinanceiroService dashboardFinanceiroService)
     : ControllerBase
    {
        [HttpGet("obter-dashboard")]
        public async Task<IActionResult> ObterDashboard(
         [FromQuery] int? ano,
         [FromQuery] int? mes)
        {
            var result = await dashboardFinanceiroService.ObterDashboardAsync(ano, mes);
            return Ok(result);
        }
    }
}
