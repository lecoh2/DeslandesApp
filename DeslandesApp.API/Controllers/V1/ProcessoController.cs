using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Processo;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/processo")]
    [ApiController]    
       public class ProcessoController(IProcessoService processoService) : ControllerBase
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
        }
}
