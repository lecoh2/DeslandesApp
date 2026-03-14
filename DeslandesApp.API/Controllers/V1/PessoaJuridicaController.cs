using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeslandesApp.API.Controllers.V1
{
    [Route("api/v1/pessoa-juridica")]
    [ApiController]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly IPessoaJuridicaService _pessoaService;

        public PessoaJuridicaController(IPessoaJuridicaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost]
        public async Task<IActionResult> PostPessoaJuridicaAsync([FromBody] PessoaJuridicaRequest request)
        {
            try
            {
                var response = await _pessoaService.AdicionarAsync(request);
                return StatusCode(StatusCodes.Status201Created, new
                {
                    success = true,
                    message = $"Cliente {response.Nome} cadastrado com sucesso.",
                    data = response
                });
            }
            catch (Exception ex)
            {
                // Log completo da exceção
                //  Console.WriteLine(ex.ToString()); // ou use ILogger
                return StatusCode(500, new { erroReal = ex.Message, stack = ex.StackTrace });
            }
        }

        //    public async Task<IActionResult> PostAsync([FromBody] PessoaFisicaRequest request) 
        //    {
        //        try {
        //            var response = await _pessoaService.AdicionarAsync(request);
        //            return StatusCode(StatusCodes.Status201Created, new 
        //            { success = true, message = $"Cliente {response.Nome} cadastrado com sucesso.",
        //                data = response });
        //        }
        //        catch (Exception ex)
        //        { return StatusCode(500, new { erroReal = ex.Message, stack = ex.StackTrace }); } }
        //}
    }
}


