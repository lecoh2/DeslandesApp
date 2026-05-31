using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaixaFinanceiraController : ControllerBase
    {
        private readonly BaixaFinanceiraService _service;

        public BaixaFinanceiraController(BaixaFinanceiraService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BaixaFinanceira request)
        {
            var result = await _service.AdicionarAsync(request);

            return Ok(result);
        }
    }
}
