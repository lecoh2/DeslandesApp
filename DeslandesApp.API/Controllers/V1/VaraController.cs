using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Setor;
using DeslandesApp.Domain.Models.Dtos.Responses.Setor;
using DeslandesApp.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/vara")]
    [ApiController]
    public class VaraController(IVaraService varaService) : ControllerBase
    {
        //[HttpPost]
        //[ProducesResponseType(typeof(SetorResponse), 201)]
        //public async Task<IActionResult> PostAsync([FromBody] SetorRequest request)
        //{
        //    try
        //    {
        //        var response = await setorService.AdicionarAsync(request);

        //        return StatusCode(201, new
        //        {
        //            success = true,
        //            message = $"Setor {response.NomeSetor} cadastrado com sucesso.",
        //            data = response
        //        });
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return BadRequest(new
        //        {
        //            success = false,
        //            message = ex.Errors.Select(e => e.ErrorMessage)
        //        });
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        return BadRequest(new
        //        {
        //            success = false,
        //            message = ex.Message
        //        });
        //    }
        //}

        //[HttpPut]
        //public async Task<IActionResult> PutAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteAsync()
        //{
        //    throw new NotImplementedException();
        //}

        [HttpGet("consultar-vara")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await varaService.ConsultarAsync();
            return Ok(result);
        }

        //  [HttpPost("adicionar-grupo-setor/{idUsuario:guid}/{idSetor:guid}")]
        //    [ProducesResponseType(StatusCodes.Status200OK)]
        //    public async Task<IActionResult> AdicionarGrupoSetor(Guid idUsuario, Guid idSetor)
        //    {
        //        await setorService.AdicionarSetorAsync(idUsuario, idSetor);

        //        return Ok(new
        //        {
        //            success = true,
        //            message = "Setor adicionado ao usuário com sucesso."
        //        });
        //    }

        //    [HttpDelete("remover-grupo-setor/{idUsuario:guid}/{idSetor:guid}")]
        //    [ProducesResponseType(StatusCodes.Status200OK)]
        //    public async Task<IActionResult> RemoverGrupoSetor(Guid idUsuario, Guid idSetor)
        //    {
        //        await setorService.RemoverSetorAsync(idUsuario, idSetor);

        //        return Ok(new
        //        {
        //            success = true,
        //            message = "Setor removido do usuário com sucesso."
        //        });
        //    }
        //}
    }

}