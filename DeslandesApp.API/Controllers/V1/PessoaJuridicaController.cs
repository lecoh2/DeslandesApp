using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/pessoa-juridica")]
    [ApiController]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly IPessoaJuridicaService _pessoaService;

        public PessoaJuridicaController(IPessoaJuridicaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost]
        public async Task<IActionResult> PostPessoaJuridicaAsync([FromBody] PessoaJuridicaRequest request)
        {
            try
            {
                var response = await _pessoaService.AdicionarAsync(request);
                return StatusCode(StatusCodes.Status201Created, new
                {
                    success = true,
                    message = $"Cliente {response.Nome} cadastrado com sucesso.",
                    data = response
                });
            }
            catch (Exception ex)
            {
                // Log completo da exceção
                //  Console.WriteLine(ex.ToString()); // ou use ILogger
                return StatusCode(500, new { erroReal = ex.Message, stack = ex.StackTrace });
            }
        }

        //    public async Task<IActionResult> PostAsync([FromBody] PessoaFisicaRequest request) 
        //    {
        //        try {
        //            var response = await _pessoaService.AdicionarAsync(request);
        //            return StatusCode(StatusCodes.Status201Created, new 
        //            { success = true, message = $"Cliente {response.Nome} cadastrado com sucesso.",
        //                data = response });
        //        }
        //        catch (Exception ex)
        //        { return StatusCode(500, new { erroReal = ex.Message, stack = ex.StackTrace }); } }
        //}

        [HttpGet("consultar-pessoa-juridica-paginacao")]
        public async Task<IActionResult> ConsultarPessoaJuridicaPaginacao(
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] string? searchTerm = null)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);

            var usuarioPaged = await _pessoaService
                .ConsultarPessoaJuridicaPaginacaoAsync(pageNumber, pageSize, searchTerm);

            return Ok(usuarioPaged);
        }

        [HttpPut("atualizar-pessoa-juridica{id}")]
        [ProducesResponseType(typeof(UsuariosResponse), 200)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] PessoaJuridicaUpdateRequest request)
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


