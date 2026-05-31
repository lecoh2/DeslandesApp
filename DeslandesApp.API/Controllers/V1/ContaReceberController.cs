using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/conta-receber")]
    [ApiController]
    public class ContaReceberController(
        IContaReceberService contaReceberService
    ) : ControllerBase
    {
        [HttpPost("cadastrar-conta-receber")]
        [ProducesResponseType(typeof(ContaReceberResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(
            [FromBody] ContaReceberRequest request)
        {
            var response = await contaReceberService
                .AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = "Conta a receber cadastrada com sucesso.",
                data = response
            });
        }

        [HttpPut("atualizar-conta-receber/{id:guid}")]
        [ProducesResponseType(typeof(ContaReceberResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(
            Guid id,
            [FromBody] ContaReceberUpdateRequest request)
        {
            var response = await contaReceberService
                .ModificarAsync(id, request);

            return Ok(new
            {
                success = true,
                message = "Conta a receber atualizada com sucesso.",
                data = response
            });
        }

        [HttpDelete("excluir-conta-receber/{id:guid}")]
        [ProducesResponseType(typeof(ContaReceberResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await contaReceberService
                .ExcluirAsync(id);

            return Ok(new
            {
                success = true,
                message = "Conta a receber excluída com sucesso.",
                data = response
            });
        }

        [HttpGet("consultar-contas-receber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarAsync()
        {
            var result = await contaReceberService
                .ConsultarAsync();

            return Ok(result);
        }

        [HttpGet("consultar-conta-receber-paginacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarPaginacao(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);

            var result = await contaReceberService
                .ConsultarAsync(pageNumber, pageSize);

            return Ok(result);
        }

        [HttpPost("baixar-conta-receber/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BaixarConta(
            Guid id,
            [FromBody] ContaReceberBaixaRequest request)
        {
            await contaReceberService
                .BaixarAsync(id, request);

            return Ok(new
            {
                success = true,
                message = "Baixa realizada com sucesso."
            });
        }
    }
}