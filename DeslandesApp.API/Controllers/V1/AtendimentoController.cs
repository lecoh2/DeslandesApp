using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Requests.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/atendimento")]
    [ApiController]
    public class AtendimentoController(IAtendimentoService atendimentoService, IGrupoEtiquetaAtendimentoServices grupoEtiquetaAtendimento) : ControllerBase
    {
        [HttpPost("cadastrar-atendimento")]
        [ProducesResponseType(typeof(CriarAtendimentoClienteResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] CriarAtendimentoClienteRequest request)
        {
            var response = await atendimentoService.AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Atendimento {response.Assunto} cadastrado com sucesso.",
                data = response
            });
        }
        [HttpPut("atualizar-atendimento/{id}")]
        [ProducesResponseType(typeof(CriarAtendimentoClienteResponse), 200)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] AtendimentoClienteUpdateRequest request)
        {
            var response = await atendimentoService.ModificarAsync(id, request);
            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Atendimento {response.Assunto} atualizado com sucesso.",
                data = response
            });
        }
        [HttpGet("consultar-atendimento-paginacao")]
        public async Task<IActionResult> ConsultarAtendimentoPaginacao(
       [FromQuery] int pageNumber = 1,
       [FromQuery] int pageSize = 10,
       [FromQuery] string? searchTerm = null)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);

            var atendimentoPaged = await atendimentoService
                .ConsultarAtendimentoPaginacaoAsync(pageNumber, pageSize, searchTerm);

            return Ok(atendimentoPaged);
        }
    
    [HttpPost("adicionar-grupo-etiqueta-atendimento/{idEtiqueta:guid}/{idAtendimento:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AdicionarGrupoEtiqutaAtendimento(Guid idEtiqueta, Guid idAtendimento)
        {
             await grupoEtiquetaAtendimento.AdicionarEtiquetaAtendimentoAsync(idEtiqueta, idAtendimento);

            return Ok(new
            {
                success = true,
                message = $"Etiqueta adicionada ao processo com sucesso"

            });
        }

        [HttpDelete("remover-grupo-etiqueta-atendimento/{idEtiqueta:guid}/{idAtendimento:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoverGrupoEtiquetaAtendimento(Guid idEtiqueta, Guid idAtendimento)
        {
           await grupoEtiquetaAtendimento.RemoverEtiquetaAtendimentoAsync(idEtiqueta, idAtendimento);

            return Ok(new
            {
                success = true,
                message = $"Etiqueta  removida do processo com sucesso."
            });
        }
        [HttpGet("consultar-atendiemnto-autocomplete")]
        public async Task<IActionResult> ConsultarResumo([FromQuery] string? termo = null)
        {
            var result = await atendimentoService.ConsultarAtendimentoAutoCompleteAsync(termo);

            return Ok(result);
        }
        [HttpGet("obter-atendimento-por-id/{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var tarefa = await atendimentoService.ObterPorIdAsync(id);

            if (tarefa == null)
                return NotFound("Tarefa não encontrada.");

            return Ok(tarefa);
        }
        [HttpGet("ultimos-atendimentos")]
        public async Task<IActionResult> ConsultarUltimos([FromQuery] int quantidade = 5)
        {
            var result = await atendimentoService.ConsultarUltimosAsync(quantidade);

            return Ok(result);
        }
        [HttpGet("consultar-graficos-atendimento")]
        public async Task<IActionResult> ConsultarGraficoAtendimento()
        {
            var resultado = await atendimentoService.ConsultarGraficAtendimento();
            return Ok(resultado);
        }
        [HttpGet("contar-atendimento-anoatual")]
        public async Task<IActionResult> ContarProcessoAnoAtual()
        {
            var resultado = await atendimentoService.ContarAtendimentoAnoAtual();
            return Ok(resultado);
        }
        [HttpGet("contar-atendimento-total")]
        public async Task<IActionResult> ContarTotal()
        {
            var total = await atendimentoService.ContarTotal();
            return Ok(total);
        }
    }
}
