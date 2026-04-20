using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Responses.Etiquetas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{

    [Route("api/v1/etiquetas")]
    [ApiController]
    public class EtiquetasControllers(IEtiquetasService etiquetasService) : ControllerBase
    {
        [HttpGet("consultar-etiquetas")]
        [ProducesResponseType(typeof(IEnumerable<EtiquetaResponse>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await etiquetasService.ConsultarAsync();
            return Ok(response);
        }
    }
}
