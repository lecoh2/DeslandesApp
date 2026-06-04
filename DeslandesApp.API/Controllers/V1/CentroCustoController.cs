using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.CentroCusto;
using DeslandesApp.Domain.Models.Dtos.Responses.CentroCusto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/centro-custo")]
    [ApiController]
    public class CentroCustoController(
          ICentroCustoService centroCustoService
      ) : ControllerBase
    {
        [HttpPost("cadastrar-centro-custo")]
        [ProducesResponseType(typeof(CentroCustoResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(
            [FromBody] CentroCustoRequest request)
        {
            var response = await centroCustoService
                .AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Centro de custo {response.Nome} cadastrado com sucesso.",
                data = response
            });
        }

        [HttpPut("atualizar-centro-custo/{id:guid}")]
        [ProducesResponseType(typeof(CentroCustoResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(
            Guid id,
            [FromBody] CentroCustoUpdateRequest request)
        {
            var response = await centroCustoService
                .ModificarAsync(id, request);

            return Ok(new
            {
                success = true,
                message = $"Centro de custo {response.Nome} atualizado com sucesso.",
                data = response
            });
        }

        [HttpDelete("remover-centro-custo/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await centroCustoService
                .ExcluirAsync(id);

            return Ok(new
            {
                success = true,
                message = $"Centro de custo {response.Nome} removido com sucesso.",
                data = response
            });
        }

        [HttpGet("consultar-centro-custo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarAsync()
        {
            var result = await centroCustoService
                .ConsultarAsync();

            return Ok(result);
        }

        [HttpGet("consultar-centro-custo-paginacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarPaginacaoAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;

            pageSize = pageSize <= 0
                ? 10
                : Math.Min(pageSize, 100);

            var result = await centroCustoService
                .ConsultarAsync(pageNumber, pageSize);

            return Ok(result);
        }
        [HttpGet("obter-centro-custo-por-id/{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var result = await centroCustoService.ObterPorIdAsync(id);

            return Ok(result);
        }
    }

}
