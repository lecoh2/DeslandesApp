using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.Atendimento;
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
    }
}
