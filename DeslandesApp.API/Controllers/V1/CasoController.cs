using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.Caso;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/caso")]
    [ApiController]
    public class CasoController(ICasoService casofaService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CriarCasoResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] CriarCasoRequest request)
        {
            var response = await casofaService.AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Caso {response.Titulo} cadastrado com sucesso.",
                data = response
            });
        }
    }
}