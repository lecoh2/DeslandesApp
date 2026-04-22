using Azure;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Caso;
using DeslandesApp.Domain.Models.Dtos.Requests.Comentarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Caso;
using DeslandesApp.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/comentarios")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioService _service;

        public ComentarioController(IComentarioService service)
        {
            _service = service;
        }

        // =========================
        // 📝 CRIAR COMENTÁRIO
        // =========================
        [HttpPost("cadastar-comentario")]
        public async Task<IActionResult> Criar([FromBody] CriarComentarioRequest request)
        {
           var response = await _service.CriarComentario(request);
            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = $"Comentário cadastrado com sucesso.",
                data = response
            });
        }
     

        // =========================
        // 📄 LISTAR COMENTÁRIOS
        // =========================
        [HttpGet("consultar-comentarios")]
        public async Task<IActionResult> Obter(
            [FromQuery] Guid? tarefaId,
            [FromQuery] Guid? eventoId)
        {
            var comentarios = await _service.ObterComentarios(tarefaId, eventoId);
            return Ok(comentarios);
        }
    }
}
