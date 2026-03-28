using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Processo;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/processo")]
    [ApiController]
    public class ProcessoController(IProcessoService processoService, IGrupoClienteProcessoService grupoClienteProcessoService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ProcessoResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] ProcessoRequest request)
        {
            var response = await processoService.AdicionarAsync(request);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Processo {response.NumeroProcesso} cadastrado com sucesso.",
                data = response
            });
        }

        [HttpGet("consultar-processo-paginacao")]
        public async Task<IActionResult> ConsultarProcessoPaginacao(
       [FromQuery] int pageNumber = 1,
       [FromQuery] int pageSize = 10,
       [FromQuery] string? searchTerm = null)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);

            var proessoPaged = await processoService
                .ConsultarProcessoPaginacaoAsync(pageNumber, pageSize, searchTerm);

            return Ok(proessoPaged);
        }
    
       [HttpPut("atualizar-processo{id}")]
        [ProducesResponseType(typeof(ProcessoResponse), 200)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] ProcessoUpdateRequest request)
        {
            var response = await processoService.ModificarAsync(id, request);
            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Proceso {response.Pasta} atualizado com sucesso.",
                data = response
            });
        }

        [HttpPost("adicionar-grupo-cliente-processo/{idPessoa:guid}/{idProcesso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AdicionarGrupoClienteProcesso(Guid idPessoa, Guid idProcesso)
        {
            await grupoClienteProcessoService.AdicionarClienteProcessoAsync(idPessoa, idProcesso);

            return Ok(new
            {
                success = true,
                message = "Setor adicionado ao usuário com sucesso."
            });
        }

        [HttpDelete("remover-grupo-cliente-processo/{idPessoa:guid}/{idProcesso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoverGrupoSetor(Guid idPessoa, Guid idProcesso)
        {
            await grupoClienteProcessoService.RemoverClienteProcessoAsync(idPessoa, idProcesso);

            return Ok(new
            {
                success = true,
                message = "Setor removido do usuário com sucesso."
            });
        }

        [HttpPost("adicionar-grupo-envolvidos-processo/{idPessoa:guid}/{idProcesso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AdicionarGrupoEnvolvidosProcesso(Guid idPessoa, Guid idProcesso)
        {
            //await processoService.AdicionarEnvolvidosProcessoAsync(idPessoa, idProcesso);

            return Ok(new
            {
                success = true,
                message = "Setor adicionado ao usuário com sucesso."
            });
        }

        [HttpDelete("remover-grupo-envolvidos-processo/{idPessoa:guid}/{idProcesso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoverGrupoEnvolvidosProcesso(Guid idPessoa, Guid idProcesso)
        {
           // await processoService.RemoverEnvolvidosProcessoAsync(idPessoa, idProcesso);

            return Ok(new
            {
                success = true,
                message = "Setor removido do usuário com sucesso."
            });
        }
        [HttpPost("adicionar-grupo-etiqueta-processo/{idEtiqueta:guid}/{idProcesso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AdicionarGrupoEtiqutaProcesso(Guid idEtiqueta, Guid idProcesso)
        {
           // await processoService.AdicionarEtiquetaProcessoAsync(idEtiqueta, idProcesso);

            return Ok(new
            {
                success = true,
                message = "Etiquta adicionada ."
            });
        }

        [HttpDelete("remover-grupo-etiqueta-processo/{idEtiqueta:guid}/{idProcesso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoverGrupoEtiquetaProcesso(Guid idEtiqueta, Guid idProcesso)
        {
           // await processoService.RemoverEtiquetaProcessoAsync(idEtiqueta, idProcesso);

            return Ok(new
            {
                success = true,
                message = "Etiqueta removida d."
            });
        }
    }
}
