using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/pessoa-fisica")]
    [ApiController]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IPessoaFisicaService _pessoaService;

        public PessoaFisicaController(IPessoaFisicaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost("cadastrar-pessoa-fisica")]
        public async Task<IActionResult> PostPessoaFisicaAsync([FromBody] PessoaFisicaRequest request)
        {
            var response = await _pessoaService.AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Cliente {response.Nome} cadastrado com sucesso.",
                data = response
            });
        }
        [HttpGet("consultar-pessoa-fisica-paginacao")]
        public async Task<IActionResult> ConsultarUsuarioPaginacao(
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] string? searchTerm = null)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);

            var usuarioPaged = await _pessoaService
                .ConsultarPessoaFisicaPaginacaoAsync(pageNumber, pageSize, searchTerm);

            return Ok(usuarioPaged);
        }

        [HttpPut("atualizar-pessoa-fisica{id}")]
        [ProducesResponseType(typeof(UsuariosResponse), 200)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] PessoaFisicaUpdateRequest request)
        {
            var response = await _pessoaService.ModificarAsync(id, request);
            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Usuário {response.Nome} atualizado com sucesso.",
                data = response
            });
        }
      
    }
}

