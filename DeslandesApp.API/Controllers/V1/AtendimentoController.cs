using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.Atendimento;
using DeslandesApp.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/atendimento")]
    [ApiController]
    public class AtendimentoController(IAtendimentoService atendiemntofaService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CriarAtendimentoClienteResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] CriarAtendimentoClienteRequest request)
        {
            var response = await atendiemntofaService.AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Atendimento {response.Assunto} cadastrado com sucesso.",
                data = response
            });
        }
    
     [HttpGet("consultar-atendimento-paginacao")]
        public async Task<IActionResult> ConsultarAtendimentoPaginacao(
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] string? searchTerm = null)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);

            var atendimentoPaged = await atendiemntofaService
                .ConsultarAtendimentoPaginacaoAsync(pageNumber, pageSize, searchTerm);

            return Ok(atendimentoPaged);
        }
    }
}
