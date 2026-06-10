using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.CategoriaFinanceira;
using DeslandesApp.Domain.Models.Dtos.Responses.CategoriaFinanceira;
using DeslandesApp.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/categoria-financeira")]
    [ApiController]
    public class CategoriaFinanceiraController(
        ICategoriaFinanceiraService categoriaFinanceiraService
    ) : ControllerBase
    {
        [HttpPost("cadastrar-categoria-financeira")]
        [ProducesResponseType(typeof(CategoriaFinanceiraResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(
            [FromBody] CategoriaFinanceiraRequest request)
        {
            var response =
                await categoriaFinanceiraService.AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Categoria financeira {response.Nome} cadastrada com sucesso.",
                data = response
            });
        }

        [HttpPut("atualizar-categoria-financeira/{id:guid}")]
        public async Task<IActionResult> PutAsync(
            Guid id,
            [FromBody] CategoriaFinanceiraUpdateRequest request)
        {
            var response =
                await categoriaFinanceiraService.ModificarAsync(id, request);

            return Ok(new
            {
                success = true,
                message = $"Categoria financeira {response.Nome} atualizada com sucesso.",
                data = response
            });
        }

        [HttpDelete("remover-categoria-financeira/{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response =
                await categoriaFinanceiraService.ExcluirAsync(id);

            return Ok(new
            {
                success = true,
                message = $"Categoria financeira {response.Nome} removida com sucesso.",
                data = response
            });
        }

      

        [HttpGet("consultar-categoria-financeira-paginacao")]
        public async Task<IActionResult> ConsultarPaginacaoAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;

            pageSize = pageSize <= 0
                ? 10
                : Math.Min(pageSize, 100);

            var result =
                await categoriaFinanceiraService.ConsultarAsync(
                    pageNumber,
                    pageSize);

            return Ok(result);
        }

        [HttpGet("obter-categoria-financeira-por-id/{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var result =
                await categoriaFinanceiraService.ObterPorIdAsync(id);

            return Ok(result);
        }
        [HttpGet("consultar-categoria-financeira")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await categoriaFinanceiraService.ConsultarAsync();
            return Ok(result);
        }
    }
}