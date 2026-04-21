using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/atividade")]
    [ApiController]
    public class DetalheAtividadeController : ControllerBase
    {
        private readonly IDetalheAtividadeService _detalheAtividadeService;

        public DetalheAtividadeController(IDetalheAtividadeService detalheAtividadeService)
        {
            _detalheAtividadeService = detalheAtividadeService;
        }

        [HttpGet("{id:guid}/detalhes/{tipo}")]
        public async Task<IActionResult> ObterDetalhes(Guid id, TipoAtividade tipo)
        {
            var result = await _detalheAtividadeService.ObterDetalhesAsync(id, tipo);
            return Ok(result);
        }
    }
}
