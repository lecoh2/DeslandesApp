using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/kanban")]
    [ApiController]
    public class KanbanController : ControllerBase
    {
        private readonly IKanbanService _kanbanService;

        public KanbanController(IKanbanService kanbanService)
        {
            _kanbanService = kanbanService;
        }

        [HttpGet("consultar-kanban")]
        public async Task<IActionResult> ObterKanban()
        {
            var result = await _kanbanService.ObterKanbanAsync();
            return Ok(result);
        }
        [HttpPut("kanban/{id}/status")]
        public async Task<IActionResult> AtualizarStatus(Guid id, [FromBody] StatusGeralKanban status)
        {
            await _kanbanService.AtualizarStatusAsync(id, (StatusGeralKanban)status);
            return NoContent();
        }
    }
}
