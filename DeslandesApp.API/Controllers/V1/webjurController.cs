using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Responses.WebJur;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeslandesApp.Domain.Models.Dtos.Requests.WebJur;
namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/webjur")]
    [ApiController]
    public class WebJurController(IWebJurService webJurService) : ControllerBase
    {
        // =========================
        // 🔄 SINCRONIZAÇÃO
        // =========================

        [HttpPost("sincronizar")]
        public async Task<IActionResult> SincronizarTodosAsync()
        {
            await webJurService.SincronizarTodosProcessosAsync();
            return Ok(new { message = "Sincronização de todos os processos iniciada." });
        }

        [HttpPost("sincronizar/monitorados")]
        public async Task<IActionResult> SincronizarMonitoradosAsync()
        {
            await webJurService.SincronizarProcessosMonitoradosAsync();
            return Ok(new { message = "Sincronização de processos monitorados iniciada." });
        }

        [HttpPost("sincronizar/tudo")]
        public async Task<IActionResult> SincronizarTudoAsync()
        {
            await webJurService.SincronizarProcessosMonitoradosAsync();
            await webJurService.ImportarPublicacoesAsync();

            return Ok(new { message = "WebJur sincronizado com sucesso." });
        }

        [HttpPost("publicacoes/{id:guid}/sincronizar")]
        public async Task<IActionResult> SincronizarPublicacao(Guid id)
        {
            await webJurService.SincronizarPublicacaoAsync(id);

            return Ok(new { message = "Publicação sincronizada com sucesso." });
        }

        // =========================
        // 📄 PUBLICAÇÕES
        // =========================

        [HttpGet("publicacoes/paginacao")]
        public async Task<IActionResult> ConsultarPublicacoesPaginacao(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : System.Math.Min(pageSize, 100);

            var result = await webJurService
                .ConsultarPublicacoesPaginadasAsync(pageNumber, pageSize, searchTerm);

            return Ok(result);
        }

        [HttpGet("publicacoes/{id:guid}")]
        [ProducesResponseType(typeof(WebJurPublicacaoDetalheResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterDetalhe(Guid id)
        {
            try
            {
                var result = await webJurService.ObterDetalheAsync(id);
                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPost("publicacoes/importar")]
        public async Task<IActionResult> ImportarPublicacoesAsync()
        {
            await webJurService.ImportarPublicacoesAsync();
            return Ok(new { message = "Importação de publicações executada com sucesso." });
        }

        // =========================
        // 💬 COMENTÁRIOS
        // =========================

        [HttpPost("publicacoes/{id:guid}/comentarios")]
        public async Task<IActionResult> AdicionarComentario(
            Guid id,
            [FromBody] WebJurComentarioResponse request)
        {
            await webJurService.AdicionarComentarioAsync(id, request);

            return Ok(new { message = "Comentário adicionado com sucesso." });
        }

        // =========================
        // 👁 VISUALIZAÇÕES
        // =========================

        [HttpPost("publicacoes/{id:guid}/visualizar")]
        public async Task<IActionResult> RegistrarVisualizacao(Guid id)
        {
            await webJurService.RegistrarVisualizacaoAsync(id);

            return Ok();
        }

        // =========================
        // 📄 PDF
        // =========================

        [HttpGet("publicacoes/{id:guid}/pdf")]
        public async Task<IActionResult> DownloadPdf(Guid id)
        {
            var arquivo = await webJurService.ObterPdfAsync(id);

            return File(
                arquivo.Conteudo,
                "application/pdf",
                arquivo.NomeArquivo);
        }

        // =========================
        // ⚙ PROCESSOS / TRIBUNAL
        // =========================

        [HttpPost("processo/{processoId:guid}")]
        public async Task<IActionResult> AtualizarProcessoAsync(Guid processoId)
        {
            var result = await webJurService.AtualizarProcessoAsync(processoId);

            if (!result)
                return NotFound(new { message = "Processo não encontrado." });

            return Ok(new { message = "Processo sincronizado com sucesso." });
        }

        [HttpGet("andamentos/{processoId:guid}")]
        public async Task<IActionResult> ConsultarAndamentosAsync(Guid processoId)
        {
            var result = await webJurService.ConsultarAndamentosAsync(processoId);
            return Ok(result);
        }

        [HttpGet("verificar/{numeroProcesso}")]
        public async Task<IActionResult> VerificarProcessoAsync(string numeroProcesso)
        {
            var result = await webJurService.VerificarProcessoExisteAsync(numeroProcesso);
            return Ok(new { existe = result });
        }
    }
}
