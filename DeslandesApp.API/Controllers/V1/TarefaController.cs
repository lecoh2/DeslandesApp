using Azure;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests;
using DeslandesApp.Domain.Models.Dtos.Requests.ListaTarefas;
using DeslandesApp.Domain.Models.Dtos.Requests.Processo;
using DeslandesApp.Domain.Models.Dtos.Requests.Tarefa;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Tarefa;
using DeslandesApp.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/tarefa")]
    [ApiController]
    public class TarefaController(ITarefaService tarefaService, IGrupoTarefaResponsaveisService grupoTarefaResponsaveisService) : ControllerBase
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

        [HttpGet("consultar-tarefa-paginacao")]
        public async Task<IActionResult> ConsultarTarefaPaginacao(
   [FromQuery] int pageNumber = 1,
   [FromQuery] int pageSize = 10,
   [FromQuery] string? searchTerm = null)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);

            var tarefaPaged = await tarefaService
                .ConsultarTarefaPaginacaoAsync(pageNumber, pageSize, searchTerm);

            return Ok(tarefaPaged);
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
        [HttpPost("adicionar-grupo-tarefa-responsaveis/{idEtiqueta:guid}/{idProcesso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AdicionarGrupoEtiqutaProcesso(Guid idEtiqueta, Guid idProcesso)
        {
            var response = await grupoTarefaResponsaveisService.AdicionarTarefaResponaveisAsync(idEtiqueta, idProcesso);

            return Ok(new
            {
                success = true,
                message = $"Responsavável {response.nome}, adicionado(a) da tarefa com sucesso."

            });
        }

        [HttpDelete("remover-grupo-tarefa-responsaveis/{idPessoa:guid}/{idTarefa:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoverGrupoEtiquetaProcesso(Guid idPessoa, Guid idTarefa)
        {
            var response =  await grupoTarefaResponsaveisService.RemoverTarefaResponsaveisAsync(idPessoa, idTarefa);

            return Ok(new
            {
                success = true,
                message = $"Responsavável {response.nome}, excluido(a) da tarefa com sucesso."
            });
        }
    }
}
