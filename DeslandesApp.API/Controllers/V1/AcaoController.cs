using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/acao")]
    [ApiController]
    public class AcaoController(IAcaoService acaoService) : ControllerBase
    {
        [HttpGet("consultar-acao")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await acaoService.ConsultarAsync();
            return Ok(result);
        }
    }
}
