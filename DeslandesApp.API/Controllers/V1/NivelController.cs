using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Nivel;
using DeslandesApp.Domain.Models.Dtos.Responses.Nivel;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Services;
using DeslandesApp.Domain.Utils;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/nivel")]
    [ApiController]
    public class NivelController(INivelServices nivelService) : ControllerBase 
    {
        [HttpPost]
        [ProducesResponseType(typeof(NivelResponse), 201)]
        public async Task<IActionResult> PostAsync([FromBody] NivelRequest request)
        {
            try
            {
                var response = await nivelService.AdicionarAsync(request);

                return StatusCode(201, new
                {
                    success = true,
                    message = $"Nivel {response.NomeNivel} cadastrado com sucesso.",
                    data = response
                });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Errors.Select(e => e.ErrorMessage)
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync()
        {
            throw new NotImplementedException();
        }

     
        [HttpGet]
        [ProducesResponseType(typeof(PageResult<NivelResponse>), 201)]
        public async Task<IActionResult> GetAllAsync
        ([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var response = await nivelService.ConsultarAsync(pageNumber, pageSize);
            return StatusCode(200, response);
        }
        [HttpPost("adicionar-grupo-nivel/{idUsuario:guid}/{idNivel:guid}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionarGrupoNivel(Guid idUsuario, Guid idNivel)
        {
            await nivelService.AdicionarNivelAsync(idUsuario, idNivel);

            return StatusCode(StatusCodes.Status201Created, new
            {
                success = true,
                message = "Nível adicionado ao usuário com sucesso."
            });
        }
        [HttpDelete("remover-grupo-nivel/{idUsuario:guid}/{idNivel:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoverGrupoNivel(Guid idUsuario, Guid idNivel)
        {
            await nivelService.RemoverNivelAsync(idUsuario, idNivel);

            return Ok(new
            {
                success = true,
                message = "Nível removido do usuário com sucesso."
            });
        }
    }
}
