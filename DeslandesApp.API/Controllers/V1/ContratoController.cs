using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Contrato;
using DeslandesApp.Domain.Models.Dtos.Responses.Contrato;
using DeslandesApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/contrato")]
    [ApiController]
    public class ContratoController(
        IContratoService contratoService
    ) : ControllerBase
    {
        [HttpPost("cadastrar-contrato")]
        [ProducesResponseType(typeof(ContratoResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(
            [FromBody] ContratoRequest request)
        {
            var response = await contratoService
                .AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Contrato {response.Numero} cadastrado com sucesso.",
                data = response
            });
        }

        [HttpPut("atualizar-contrato/{id:guid}")]
        [ProducesResponseType(typeof(ContratoResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(
            Guid id,
            [FromBody] ContratoUpdateRequest request)
        {
            var response = await contratoService
                .ModificarAsync(id, request);

            return Ok(new
            {
                success = true,
                message = $"Contrato {response.Numero} atualizado com sucesso.",
                data = response
            });
        }

        [HttpDelete("excluir-contrato/{id:guid}")]
        [ProducesResponseType(typeof(ContratoResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await contratoService
                .ExcluirAsync(id);

            return Ok(new
            {
                success = true,
                message = "Contrato excluído com sucesso.",
                data = response
            });
        }

        [HttpGet("consultar-contratos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarAsync()
        {
            var result = await contratoService
                .ConsultarAsync();

            return Ok(result);
        }


        [HttpGet("consultar-contato-paginacao")]
        public async Task<IActionResult> ConsultarContratoPaginacao(
       [FromQuery] int pageNumber = 1,
       [FromQuery] int pageSize = 10,
       [FromQuery] string? searchTerm = null)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);

            var proessoPaged = await contratoService
                .ConsultarContratoPaginacaoAsync(pageNumber, pageSize, searchTerm);

            return Ok(proessoPaged);
        }
    }
}