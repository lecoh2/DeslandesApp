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

        [HttpPost]
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

       
    }
}
