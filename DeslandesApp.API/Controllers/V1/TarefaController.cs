using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests;
using DeslandesApp.Domain.Models.Dtos.Requests.ListaTarefas;
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
    


    [HttpPut("reordenar")]
        public async Task<IActionResult> Reordenar([FromBody] List<ReordenarListaTarefaRequest> request)
        {
            await tarefaService.ReordenarListaAsync(request);
            return NoContent();
        }
        [HttpPatch("mover")]
        public async Task<IActionResult> MoverCard([FromBody] MoverKanbanCardRequest request)
        {
            await tarefaService.MoverCardAsync(request);
            return Ok();
        }
    }
}
