
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Qualificacao;
using DeslandesApp.Domain.Models.Dtos.Responses.Qualificacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/qualificacao")]
    [ApiController]
    public class QualificacaoController(IQualidicacaoService qualificacaoService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(QualificacaoResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] QualificacaoRequest request)
        {
            var response = await qualificacaoService.AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Qualificaçao {response.NomeQualificacao} cadastrado com sucesso.",
                data = response
            });
        }
    }
}
