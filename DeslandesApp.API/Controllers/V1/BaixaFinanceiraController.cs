using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.BaixaFinanceira;
using DeslandesApp.Domain.Models.Dtos.Responses.BaixaFinanceira;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/baixa-financeira")]
    [ApiController]
    public class BaixaFinanceiraController(
        IBaixaFinanceiraService baixaFinanceiraService
    ) : ControllerBase
    {
        [HttpPost("cadastrar-baixa-financeira")]
        [ProducesResponseType(typeof(BaixaFinanceiraResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(
            [FromBody] BaixaFinanceiraRequest request)
        {
            var response = await baixaFinanceiraService
                .AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = "Baixa financeira cadastrada com sucesso.",
                data = response
            });
        }

        [HttpPut("atualizar-baixa-financeira/{id:guid}")]
        [ProducesResponseType(typeof(BaixaFinanceiraResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(
            Guid id,
            [FromBody] BaixaFinanceiraUpdateRequest request)
        {
            var response = await baixaFinanceiraService
                .ModificarAsync(id, request);

            return Ok(new
            {
                success = true,
                message = "Baixa financeira atualizada com sucesso.",
                data = response
            });
        }

        [HttpDelete("excluir-baixa-financeira/{id:guid}")]
        [ProducesResponseType(typeof(BaixaFinanceiraResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await baixaFinanceiraService
                .ExcluirAsync(id);

            return Ok(new
            {
                success = true,
                message = "Baixa financeira excluída com sucesso.",
                data = response
            });
        }

        [HttpGet("consultar-baixas-financeiras")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarAsync()
        {
            var result = await baixaFinanceiraService
                .ConsultarAsync();

            return Ok(result);
        }

        [HttpGet("obter-baixa-financeira-por-id/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var baixa = await baixaFinanceiraService
                .ObterPorIdAsync(id);

            if (baixa == null)
                return NotFound("Baixa financeira não encontrada.");

            return Ok(baixa);
        }

        [HttpGet("consultar-por-conta-receber/{contaReceberId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarPorContaReceber(
            Guid contaReceberId)
        {
            var result = await baixaFinanceiraService
                .ConsultarPorContaReceberAsync(contaReceberId);

            return Ok(result);
        }

        [HttpGet("consultar-por-conta-pagar/{contaPagarId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarPorContaPagar(
            Guid contaPagarId)
        {
            var result = await baixaFinanceiraService
                .ConsultarPorContaPagarAsync(contaPagarId);

            return Ok(result);
        }
    }
}
