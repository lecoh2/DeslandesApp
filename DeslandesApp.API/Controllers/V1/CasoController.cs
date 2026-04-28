using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Requests.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.Caso;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/caso")]
    [ApiController]
    public class CasoController(ICasoService casoService,
        IGrupoCasoClienteService grupoCasoClienteservice,
        IGrupoCasoEnvovidoService grupoCasoEnvovidoService,
        IGrupoEtiquetaCasoService grupoCasoEtiquetaService) : ControllerBase
    {
        [HttpPost("cadatrar-caso")]
        [ProducesResponseType(typeof(CriarCasoResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] CriarCasoRequest request)
        {
            var response = await casoService.AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Caso {response.Titulo} cadastrado com sucesso.",
                data = response
            });
        }
        [HttpGet("consultar-caso-paginacao")]
        public async Task<IActionResult> ConsultarCasoPaginacao(
   [FromQuery] int pageNumber = 1,
   [FromQuery] int pageSize = 10,
   [FromQuery] string? searchTerm = null)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);

            var proessoPaged = await casoService
                .ConsultarCasoPaginacaoAsync(pageNumber, pageSize, searchTerm);

            return Ok(proessoPaged);
        }
        [HttpPut("atualizar-caso{id}")]
        [ProducesResponseType(typeof(CriarCasoResponse), 200)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] CasoUpdateRequest request)
        {
            var response = await casoService.ModificarAsync(id, request);
            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Proceso {response.Titulo} atualizado com sucesso.",
                data = response
            });
        }

        [HttpPost("adicionar-grupo-cliente-caso/{idPessoa:guid}/{idCaso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AdicionarGrupoClienteProcesso(Guid idPessoa, Guid idCaso)
        {
            var response = await grupoCasoClienteservice.
                AdicionarGrupoCasoClienteAsync(idPessoa, idCaso);

            return Ok(new
            {
                success = true,
                message = $"Cliente {response.Nome}, adicionado ao processo com sucesso."
            });
        }

        [HttpDelete("remover-grupo-cliente-caso/{idPessoa:guid}/{idCaso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoverGrupoSetor(Guid idPessoa, Guid idCaso)
        {

            await grupoCasoClienteservice.RemoverGrupoCasoClienteAsync(idPessoa, idCaso);

            return Ok(new
            {
                success = true,
                message = "Cliente removido do processo com sucesso."
            });
        }

        [HttpPost("adicionar-grupo-envolvidos-casao/{idPessoa:guid}/{idCaso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AdicionarGrupoEnvolvidosProcesso(Guid idPessoa, Guid idCaso)
        {
          var response = await grupoCasoEnvovidoService
                .AdicionarGrupoCasoEnvolvidoAsync(idPessoa, idCaso);

            return Ok(new
            {
                success = true,
               message = $"Envolvido {response.Nome}, adicionado ao processo com sucesso."
            });
        }

        [HttpDelete("remover-grupo-envolvidos-processo/{idPessoa:guid}/{idCaso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoverGrupoEnvolvidosProcesso(Guid idPessoa, Guid idCaso)
        {
           await grupoCasoEnvovidoService.RemoverGrupoCasoEnvolvidoAsync(idPessoa, idCaso);

            return Ok(new
            {
                success = true,
                message = "Envolvido removido do processo com sucesso."
            });
        }
        [HttpPost("adicionar-grupo-etiqueta-caso/{idEtiqueta:guid}/{idCaso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AdicionarGrupoEtiqutaProcesso(Guid idEtiqueta, Guid idCaso)
        {
            var response = await grupoCasoEtiquetaService.AdicionarEtiquetaCasoAsync(idEtiqueta, idCaso);

            return Ok(new
            {
                success = true,
               // message = $"Etiqueta {response.nome}, adicionada ao processo com sucesso"

            });
        }

        [HttpDelete("remover-grupo-etiqueta-etiqueta/{idEtiqueta:guid}/{idProcesso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoverGrupoEtiquetaProcesso(Guid idEtiqueta, Guid idProcesso)
        {
           await grupoCasoEtiquetaService.RemoverEtiquetaCasoAsync(idEtiqueta, idProcesso);

            return Ok(new
            {
                success = true,
                message = "Etiqueta removida do processo com sucesso."
            });
        }

        [HttpGet("consultar-caso-autocpmplete")]
        public async Task<IActionResult> ConsultarCasoAutoComplete([FromQuery] string? termo = null)
        {
            var result = await casoService.ConsultarCasoAutoCompleteAsync(termo);

            return Ok(result);
        }
        [HttpGet("obter-caso-por-id/{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var caso = await casoService.ObterPorIdAsync(id);

            if (caso == null)
                return NotFound("Cso não encontrada.");

            return Ok(caso);
        }
    }
}
