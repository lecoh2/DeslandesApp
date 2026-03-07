using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Nivel;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Nivel;
using DeslandesApp.Domain.Services;
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
        public async Task<IActionResult> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
