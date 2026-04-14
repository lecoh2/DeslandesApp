using DeslandesApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/pessoas")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet("resumo")]
        public async Task<IActionResult> ConsultarResumo([FromQuery] string? termo = null)
        {
            var result = await _pessoaService.ConsultarResumoAsync(termo);

            return Ok(result);
        }
    }
}
