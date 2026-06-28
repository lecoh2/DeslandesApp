using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.ConfiguracaoFinanceira;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/configuracao-financeira")]
    [ApiController]
    public class ConfiguracaoFinanceiraController(
        IConfiguracaoFinanceiraService configuracaoFinanceiraService)
        : ControllerBase
    {
        [HttpGet("obter")]
        public async Task<IActionResult> Obter()
        {
            var result =
                await configuracaoFinanceiraService
                    .ObterAsync();

            return Ok(result);
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> Salvar(
            [FromBody] ConfiguracaoFinanceiraRequest request)
        {
            var result =
                await configuracaoFinanceiraService
                    .SalvarAsync(request);

            return Ok(result);
        }
    }
}
