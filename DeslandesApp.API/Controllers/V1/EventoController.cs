
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Evento;
using DeslandesApp.Domain.Models.Dtos.Responses.Evento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/evento")]
    [ApiController]
    public class EventoController(IEventoService eventoService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CriarEventoResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] CriarEventoRequest request)
        {
            var response = await eventoService.AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Evento {response.Titulo} cadastrado com sucesso.",
                data = response
            });
        }
    }
}