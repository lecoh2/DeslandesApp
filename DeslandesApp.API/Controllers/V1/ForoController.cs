using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Foro;
using DeslandesApp.Domain.Models.Dtos.Responses.Foro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/foro")]
    [ApiController]
    public class ForoController(IForoService foroService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ForoResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] ForoRequest request)
        {
            var response = await foroService.AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Foro {response.NomeForo} cadastrado com sucesso.",
                data = response
            });
        }
    }
}
