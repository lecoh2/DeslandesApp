using DeslandesApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{

    [Route("api/v1/notificacoes")]
    [ApiController]
    public class NotificacaoController : ControllerBase
    {
        private readonly INotificacaoService _service;

        public NotificacaoController(INotificacaoService service)
        {
            _service = service;
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> Get(Guid usuarioId)
        {
            var result = await _service.ObterNotificacoesUsuarioAsync(usuarioId);
            return Ok(result);
        }

        [HttpPut("marcar-lida/{id}")]
        public async Task<IActionResult> Marcar(Guid id)
        {
            await _service.MarcarComoLidaAsync(id);
            return Ok();
        }
    }
}
