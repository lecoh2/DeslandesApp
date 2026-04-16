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
    public class AtendimentoController(IAtendimentoService atendiemntofaService, IGrupoEtiquetaAtendimentoServices grupoEtiquetaAtendimento) : ControllerBase
    {
        [HttpPost("cadastrar-atendimento")]
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
        [HttpPut("atualizar-atenndimento{id}")]
        [ProducesResponseType(typeof(CriarAtendimentoClienteResponse), 200)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] AtendimentoClienteUpdateRequest request)
        {
            var response = await atendiemntofaService.ModificarAsync(id, request);
            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Proceso {response.Assunto} atualizado com sucesso.",
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

            var atendimentoPaged = await atendiemntofaService
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
            var result = await atendiemntofaService.ConsultarAtendimentoAutoCompleteAsync(termo);

            return Ok(result);
        }
    }
}
