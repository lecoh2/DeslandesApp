using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Responses.HistoricoGeral;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DeslandesApp.Domain.Services
{
    public class HistoricoGeralService : IHistoricoGeralService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HistoricoGeralService(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task RegistrarAsync(
            TipoEntidade entidade,
            Guid entidadeId,
            Guid? usuarioId,
            object dadosAntes,
            object dadosDepois,
            string? observacao = null)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            // 🔥 IP (proxy + local)
            var ip = httpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                     ?? httpContext?.Connection?.RemoteIpAddress?.ToString();

            if (ip == "::1")
                ip = "127.0.0.1";

            // 🔥 User Agent
            var userAgent = httpContext?.Request?.Headers["User-Agent"].ToString();

            var historico = new HistoricoGeral
            {
                Entidade = entidade,
                EntidadeId = entidadeId,
                UsuarioId = usuarioId,

                DataAlteracao = DateTime.UtcNow,

                Observacao = observacao,

                DadosAntes = dadosAntes != null
                    ? JsonConvert.SerializeObject(dadosAntes)
                    : string.Empty,

                DadosDepois = dadosDepois != null
                    ? JsonConvert.SerializeObject(dadosDepois)
                    : string.Empty,

                Ip = ip,
                UserAgent = userAgent
            };

            await _unitOfWork.HistoricoGeralRepository.AddAsync(historico);
        }

        public async Task<List<HistoricoGeralResponse>> ObterPorEntidadeAsync(
            TipoEntidade entidade,
            Guid entidadeId)
        {
            var historico = await _unitOfWork.HistoricoGeralRepository
                .ObterPorEntidadeAsync(entidade, entidadeId);

            return historico.Select(h => new HistoricoGeralResponse
            {
                Entidade = h.Entidade,
                EntidadeId = h.EntidadeId,
                DataAlteracao = h.DataAlteracao,
                Observacao = h.Observacao,

                UsuarioNome = h.Usuario != null
                    ? h.Usuario.NomeUsuario
                    : "Sistema",

                DadosAntes = h.DadosAntes,
                DadosDepois = h.DadosDepois,

                Ip = h.Ip,
                UserAgent = h.UserAgent
            }).ToList();
        }
    }
}