using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/conta-pagar")]
    [ApiController]
    public class ContaPagarController(
        IContaPagarService contaPagarService
    ) : ControllerBase
    {
        [HttpPost("cadastrar-conta-pagar")]
        [ProducesResponseType(typeof(ContaPagarResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(
            [FromBody] ContaPagarRequest request)
        {
            var response = await contaPagarService
                .AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = "Conta a pagar cadastrada com sucesso.",
                data = response
            });
        }

        [HttpPut("atualizar-conta-pagar/{id:guid}")]
        [ProducesResponseType(typeof(ContaPagarResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(
            Guid id,
            [FromBody] ContaPagarUpdateRequest request)
        {
            var response = await contaPagarService
                .ModificarAsync(id, request);

            return Ok(new
            {
                success = true,
                message = "Conta a pagar atualizada com sucesso.",
                data = response
            });
        }

        [HttpDelete("excluir-conta-pagar/{id:guid}")]
        [ProducesResponseType(typeof(ContaPagarResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await contaPagarService
                .ExcluirAsync(id);

            return Ok(new
            {
                success = true,
                message = "Conta a pagar excluída com sucesso.",
                data = response
            });
        }

        [HttpGet("consultar-contas-pagar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarAsync()
        {
            var result = await contaPagarService
                .ConsultarAsync();

            return Ok(result);
        }

        [HttpGet("consultar-conta-pagar-paginacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarPaginacao(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);

            var result = await contaPagarService
                .ConsultarPaginacaoAsync(pageNumber, pageSize);

            return Ok(result);
        }

        [HttpPost("baixar-conta-pagar/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BaixarConta(
            Guid id,
            [FromBody] ContaPagarBaixaRequest request)
        {
            await contaPagarService
                .BaixarAsync(id, request);

            return Ok(new
            {
                success = true,
                message = "Baixa realizada com sucesso."
            });
        }
        [HttpGet("obter-conta-pagar-por-id/{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var contaPagar = await contaPagarService.ObterPorIdAsync(id);

            if (contaPagar == null)
                return NotFound("Conta a Pagar não encontrada.");

            return Ok(contaPagar);
        }
    }
}