using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Utils;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
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

        [HttpPut("atualizar-usuario{id}")]
        [ProducesResponseType(typeof(UsuariosResponse),200)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UsuarioUpdateRequest request)
        {
            var response = await usuarioService.ModificarAsync(id, request);
            return StatusCode(200, response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UsuariosResponse),200)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await usuarioService.ExcluirAsync(id);
            return StatusCode(200, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PageResult<UsuariosResponse>), 201)]
        public async Task<IActionResult> GetAllAsync
            ([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var response = await usuarioService.ConsultarAsync(pageNumber, pageSize);
            return StatusCode(200, response);
        }

       [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuariosResponse),200)]
        public async Task<IActionResult>GetByIdAsync(Guid id)
        {
            var response = await usuarioService.ObterPorIdAsync(id);
            return StatusCode(200, response);
        }
        [HttpPost("autenticar-usuario")]
        public async Task<IActionResult> AutenticarUsuario([FromBody] AutenticarUsuarioRequest dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    sucesso = false,
                    mensagem = "Requisição inválida. Verifique os campos enviados.",
                    erros = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });

            try
            {
                // 🔹 Captura o IP real (considerando proxy reverso)
                var clientIp = Request.Headers.ContainsKey("X-Forwarded-For")
                    ? Request.Headers["X-Forwarded-For"].FirstOrDefault()
                    : HttpContext.Connection.RemoteIpAddress?.ToString();

                clientIp ??= "IP não identificado";

                // 🔹 Captura o User-Agent (navegador / dispositivo)
                var userAgent = Request.Headers["User-Agent"].FirstOrDefault() ?? "UserAgent não informado";

                // 🔹 Chama o serviço de autenticação
                var response = await usuarioService.AutenticarUsuarioAsync(dto, clientIp, userAgent);

                // 🔹 Retorno padronizado para sucesso
                return StatusCode(201, new
                {
                    sucesso = true,
                    mensagem = "Usuário autenticado com sucesso.",
                    dados = response
                });
            }
            catch (ApplicationException ex)
            {
                // ⚠️ Erros esperados (credenciais inválidas, conta bloqueada, etc.)
                var mensagemErro = ex.Message switch
                {
                    "Conta bloqueada. Entre em contato com o administrador." => "Conta bloqueada. Entre em contato com o administrador.",
                    "Credenciais inválidas." => "Credenciais inválidas.",
                    _ => "Falha na autenticação. Verifique seus dados. Conta bloqueada!"
                };

                return Unauthorized(new
                {
                    sucesso = false,
                    mensagem = mensagemErro
                });
            }
            catch (Exception ex)
            {
                // ⚠️ Erros inesperados (banco, mapeamento, etc.)
                return StatusCode(500, new
                {
                    sucesso = false,
                    mensagem = "Erro interno no servidor. Tente novamente mais tarde.",
                    erro = ex.Message
                });
            }
        }

        [HttpGet("consultar-usuarios-paginacao")]
        public async Task<IActionResult> ConsultarUsuarioPaginacao(
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] string? searchTerm = null)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);

            var usuarioPaged = await usuarioService
                .ConsultarUsuariosComPaginacaoAsync(pageNumber, pageSize, searchTerm);

            return Ok(usuarioPaged);
        }
    }
}
