using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Setor;
using DeslandesApp.Domain.Models.Dtos.Responses.Setor;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/setor")]
    [ApiController]
    public class SetorController(ISetorService setorService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(SetorResponse), 201)]
        public async Task<IActionResult> PostAsync([FromBody] SetorRequest request)
        {
            try
            {
                var response = await setorService.AdicionarAsync(request);

                return StatusCode(201, new
                {
                    success = true,
                    message = $"Setor {response.NomeSetor} cadastrado com sucesso.",
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
