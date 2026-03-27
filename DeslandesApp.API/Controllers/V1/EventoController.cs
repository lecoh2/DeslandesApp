
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Evento;
using DeslandesApp.Domain.Models.Dtos.Responses.Evento;
using DeslandesApp.Domain.Services;
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

        [HttpGet("consultar-evento-paginacao")]
        public async Task<IActionResult> ConsultarEventoPaginacao(
              [FromQuery] int pageNumber = 1,
              [FromQuery] int pageSize = 10,
              [FromQuery] string? searchTerm = null)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);

            var eventoPaged = await eventoService
                .ConsultarEventoPaginacaoAsync(pageNumber, pageSize, searchTerm);

            return Ok(eventoPaged);
        }
    }
}