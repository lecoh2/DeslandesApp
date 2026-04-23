using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Comentarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Comentarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class ComentarioService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : IComentarioService
    {
        public Task<ComentarioResponse> AdicionarAsync(CriarComentarioRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<ComentarioResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Comentario> CriarComentario(CriarComentarioRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            var usuarioId = ObterUsuarioId();

            if (!request.TarefaId.HasValue && !request.EventoId.HasValue)
                throw new InvalidOperationException("Comentário precisa estar vinculado.");

            if (request.TarefaId.HasValue && request.EventoId.HasValue)
                throw new InvalidOperationException("Comentário não pode ter dois vínculos.");

            var comentario = mapper.Map<Comentario>(request);

            comentario.UsuarioId = usuarioId.Value;
            comentario.DataCriacao = DateTime.Now;

            await unitOfWork.ComentarioRepository.AddAsync(comentario);
            await unitOfWork.CommitAsync();

            return comentario;
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<ComentarioResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ComentarioResponse> ModificarAsync(Guid id, UpdateComentarioRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ComentarioResponse>> ObterComentarios(Guid? tarefaId, Guid? eventoId)
        {
            var comentarios = await unitOfWork.ComentarioRepository.ObterComentarios(tarefaId, eventoId);

            return comentarios.Select(c => new ComentarioResponse
            {
                Id = c.Id,
                Texto = c.Texto,
                DataCriacao = c.DataCriacao,
                UsuarioNome = c.Usuario?.NomeUsuario ?? "Sistema"
            }).ToList();
        }

        public Task<ComentarioResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        private Guid? ObterUsuarioId()
        {
            var user = httpContextAccessor.HttpContext?.User;

            var userId = user?.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(userId))
                return null;

            return Guid.Parse(userId);
        }
    }
}
