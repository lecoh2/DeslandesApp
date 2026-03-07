using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/usuarios")]
    [ApiController]
    public class UsuariosController(IUsuarioService usuarioService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(UsuariosResponse), 201)]
        public async Task<IActionResult> PostAsync([FromBody] UsuariosRequest request)
        {
            try
            {
                var response = await usuarioService.AdicionarAsync(request);

                return StatusCode(201, new
                {
                    success = true,
                    message = $"Usuário {response.NomeUsuario} cadastrado com sucesso.",
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
        public async Task<IActionResult> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
