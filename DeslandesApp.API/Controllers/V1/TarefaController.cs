using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Processo;
using DeslandesApp.Domain.Models.Dtos.Requests.Tarefa;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Tarefa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/tarefa")]
    [ApiController]
    public class TarefaController(ITarefaService tarefaService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CriarTarefaResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] CriarTarefaRequest request)
        {
            var response = await tarefaService.AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Tarefa {response.Descricao} cadastrado com sucesso.",
                data = response
            });
        }
    }
}
