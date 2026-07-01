using Azure;
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
    public class ProcessoController(IProcessoService processoService,
        IGrupoClienteProcessoService grupoClienteProcessoService,
        IGrupoEnvolvidosProcessoService grupoEnvolvidosProcessoService,
        IGrupoEtiquetaProcessoService grupoEtiquetaProcesoService) : ControllerBase
    {
        [HttpPost("cadastrar-processo")]
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
    
       [HttpPut("atualizar-processo/{id}")]
        [ProducesResponseType(typeof(ProcessoResponse), 200)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] ProcessoUpdateRequest request)
        {
            var response = await processoService.ModificarAsync(id, request);
            return Ok(new
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
            var response = await grupoClienteProcessoService.
                AdicionarClienteProcessoAsync(idPessoa, idProcesso);

            return Ok(new
            {
                success = true,
                message = $"Cliente {response.Nome}, adicionado ao processo com sucesso."
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
                message = "Cliente removido do processo com sucesso."
            });
        }

        [HttpPost("adicionar-grupo-envolvidos-processo/{idPessoa:guid}/{idProcesso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AdicionarGrupoEnvolvidosProcesso(Guid idPessoa, Guid idProcesso)
        {
            var response = await grupoEnvolvidosProcessoService
                .AdicionarEnvolvidosProcessoAsync(idPessoa, idProcesso);

            return Ok(new
            {
                success = true,
                message = $"Envolvido {response.Nome}, adicionado ao processo com sucesso."
            });
        }

        [HttpDelete("remover-grupo-envolvidos-processo/{idPessoa:guid}/{idProcesso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoverGrupoEnvolvidosProcesso(Guid idPessoa, Guid idProcesso)
        {
            await grupoEnvolvidosProcessoService.RemoverEnvolvidosProcessoAsync(idPessoa, idProcesso);

            return Ok(new
            {
                success = true,
                message = "Envolvido removido do processo com sucesso."
            });
        }
        [HttpPost("adicionar-grupo-etiqueta-processo/{idEtiqueta:guid}/{idProcesso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AdicionarGrupoEtiqutaProcesso(Guid idEtiqueta, Guid idProcesso)
        {
            var response = await grupoEtiquetaProcesoService.AdicionarEtiquetaProcessoAsync(idEtiqueta, idProcesso);

            return Ok(new
            {
                success = true,
                message = $"Etiqueta {response.Nome}, adicionada ao processo com sucesso"
                
            });
        }

        [HttpDelete("remover-grupo-etiqueta-processo/{idEtiqueta:guid}/{idProcesso:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoverGrupoEtiquetaProcesso(Guid idEtiqueta, Guid idProcesso)
        {
           await grupoEtiquetaProcesoService.RemoverEtiquetaProcessoAsync(idEtiqueta, idProcesso);

            return Ok(new
            {
                success = true,
                message = "Etiqueta removida do processo com sucesso."
            });
        }
        [HttpGet("consultar-processo-autocomplete")]
        public async Task<IActionResult> ConsultarResumo([FromQuery] string? termo = null)
        {
            var result = await processoService.ConsultarProcessoAutoCompleteAsync(termo);

            return Ok(result);
        }
        [HttpGet("obter-processo-por-id/{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var processo = await processoService.ObterPorIdAsync(id);

            if (processo == null)
                return NotFound("Processo não encontrado.");

            return Ok(processo);
        }
        [HttpGet("ultimos-processos")]
        public async Task<IActionResult> ConsultarUltimos([FromQuery] int quantidade = 5)
        {
            var result = await processoService.ConsultarUltimosAsync(quantidade);

            return Ok(result);
        }


        //[HttpGet("consultar-cinco-ultimas-atendimentos")]
        //public async Task<IActionResult> ConsultarCincoUltimasAtendimentos()
        //{
        //    //var resultado = await _atendimentoDomainService.Consultar5UltimosAtendimento();
        //   // return Ok(resultado);
        //}

        [HttpGet("consultar-graficos-processo")]
        public async Task<IActionResult> ConsultarGraficoAtendimento()
        {
            var resultado = await processoService.ConsultarGraficoProcesso();
            return Ok(resultado);
        }
        [HttpGet("contar-processo-anoatual")]
        public async Task<IActionResult> ContarProcessoAnoAtual()
        {
            var resultado = await processoService.ContarProcessoAnoAtual();
            return Ok(resultado);
        }
        [HttpGet("contar-processos-total")]
        public async Task<IActionResult> ContarTotal()
        {
            var total = await processoService.ContarTotal();
            return Ok(total);
        }
        [HttpPost("importar-distribuicao")]
        public async Task<IActionResult> ImportarDistribuicao(IFormFile file)
        {
            var result = await processoService
                .ImportarDistribuicaoAsync(file);

            return Ok(result);
        }
        [HttpPost("sincronizar-processo/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SincronizarProcesso(Guid id)
        {
            var response = await processoService.SincronizarProcessoAsync(id);

            return Ok(new
            {
                success = true,
                message = "Processo sincronizado com sucesso.",
                data = response
            });
        }
        [HttpPost("copiar-processo/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CopiarProcesso(Guid id)
        {
            var response = await processoService.CopiarProcessoAsync(id);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = "Processo copiado com sucesso.",
                data = response
            });
        }
        [HttpGet("obter-resumo-processo/{id:guid}")]
        public async Task<IActionResult> ObterResumoProcesso(Guid id)
        {
            var processo = await processoService.ObterResumoProcessoAsync(id);

            if (processo == null)
                return NotFound("Processo não encontrado.");

            return Ok(processo);
        }
    }
}
