using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.Caso;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/caso")]
    [ApiController]
    public class CasoController(ICasoService casoService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CriarCasoResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] CriarCasoRequest request)
        {
            var response = await casoService.AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Caso {response.Titulo} cadastrado com sucesso.",
                data = response
            });
        }
        [HttpGet("consultar-caso-paginacao")]
        public async Task<IActionResult> ConsultarCasoPaginacao(
   [FromQuery] int pageNumber = 1,
   [FromQuery] int pageSize = 10,
   [FromQuery] string? searchTerm = null)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);

            var proessoPaged = await casoService
                .ConsultarCasoPaginacaoAsync(pageNumber, pageSize, searchTerm);

            return Ok(proessoPaged);
        }
    }
}
