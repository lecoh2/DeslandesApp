using DeslandesApp.Domain.Helpers;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class KanbanService : IKanbanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public KanbanService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<KanbanColuna>> ObterKanbanAsync()
        {
            // 🔹 Busca dados do banco
            var tarefas = await _unitOfWork.TarefaRepository.GetKanbanAsync();
            var eventos = await _unitOfWork.EventoRepository.GetKanbanAsync();
            var comentarios = await _unitOfWork.ComentarioRepository.ContarComentariosPorCard();
            // 🔹 Lista de cards
            var cards = new List<KanbanCard>();

            // =========================
            // TAREFAS → CARDS
            // =========================
            foreach (var t in tarefas)
            {
                cards.Add(new KanbanCard
                {
                    Id = t.Id,
                    Titulo = t.Descricao,
                    Data = t.DataTarefa,
                    Tipo = "Tarefa",
                    Prioridade = t.Prioridade,
                    PrioridadeDescricao = t.Prioridade.ToString(),
                    Status = t.StatusGeralKanban,
                    UsuarioCriacaoId = t.UsuarioCriacaoId,
                    UsuarioCriacaoNome = t.UsuarioCriacao?.NomeUsuario,
                    QuantidadeComentarios = comentarios.TryGetValue(t.Id, out var qtd)
            ? qtd
            : 0
                });
            }

            // =========================
            // EVENTOS → CARDS
            // =========================
            foreach (var e in eventos)
            {
                cards.Add(new KanbanCard
                {
                    Id = e.Id,
                    Titulo = e.Titulo,

                    Data = e.DataInicial.ToDateTime(TimeOnly.MinValue),

                    // 🔥 CORRIGIDO
                    DataInicial = e.DataInicial.ToDateTime(e.HoraInicial),
                    DataFinal = e.DataFinal?.ToDateTime(e.HoraFinal ?? TimeOnly.MinValue),

                    HoraInicial = e.HoraInicial,
                    HoraFinal = e.HoraFinal,

                    Tipo = "Evento",
                    Status = e.StatusGeralKanban,
                    UsuarioCriacaoId = e.UsuarioCriacaoId,
                    UsuarioCriacaoNome = e.UsuarioCriacao?.NomeUsuario,
                    QuantidadeComentarios = comentarios.TryGetValue(e.Id, out var qtd)
            ? qtd
            : 0
                });
            }

            // =========================
            // COLUNAS DO KANBAN (🔥 CORRETO)
            // =========================
            var colunas = Enum.GetValues(typeof(StatusGeralKanban))
                .Cast<StatusGeralKanban>()
                .Select(status => new KanbanColuna
                {
                    Status = status,
                    Nome = StatusKanbanHelper.ObterNome(status),
                    Cor = StatusKanbanHelper.ObterCor(status),
                    Cards = cards
                        .Where(c => c.Status == status)
                        .OrderBy(c => c.Data ?? DateTime.MaxValue)
                        .ToList()
                })
                .OrderBy(c => (int)c.Status)
                .ToList();

            return colunas;
        }
        public async Task AtualizarStatusAsync(Guid id, StatusGeralKanban status)
        {
            var tarefa = await _unitOfWork.TarefaRepository.GetByIdAsync(id);
            var usuarioId = ObterUsuarioId();
            if (tarefa != null)
            {
                // 🔥 ANTES
                var dadosAntes = new
                {
                    StatusGeralKanban = tarefa.StatusGeralKanban
                };

                // 🔥 ALTERA
                tarefa.StatusGeralKanban = status;

                // 🔥 DEPOIS
                var dadosDepois = new
                {
                    StatusGeralKanban = tarefa.StatusGeralKanban
                };

                // 🔥 SALVA HISTÓRICO
                await _unitOfWork.HistoricoGeralRepository.AddAsync(new HistoricoGeral
                {
                    Entidade = TipoEntidade.Tarefa,
                    EntidadeId = tarefa.Id,
                    UsuarioId = usuarioId,
                    Observacao = "Status alterado",

                    DadosAntes = JsonConvert.SerializeObject(dadosAntes),
                    DadosDepois = JsonConvert.SerializeObject(dadosDepois)
                });

                await _unitOfWork.CommitAsync();
                return;
            }

            var evento = await _unitOfWork.EventoRepository.GetByIdAsync(id);

            if (evento != null)
            {
                var dadosAntes = new
                {
                    StatusGeralKanban = evento.StatusGeralKanban
                };

                evento.StatusGeralKanban = status;

                var dadosDepois = new
                {
                    StatusGeralKanban = evento.StatusGeralKanban
                };

                await _unitOfWork.HistoricoGeralRepository.AddAsync(new HistoricoGeral
                {
                    Entidade = TipoEntidade.Evento,
                    EntidadeId = evento.Id,
                    UsuarioId = usuarioId,
                    Observacao = "Status alterado",

                    DadosAntes = JsonConvert.SerializeObject(dadosAntes),
                    DadosDepois = JsonConvert.SerializeObject(dadosDepois)
                });

                await _unitOfWork.CommitAsync();
                return;
            }

            throw new Exception("Item não encontrado");
        }

        private Guid? ObterUsuarioId()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            var userId = user?.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(userId))
                return null;

            return Guid.Parse(userId);
        }
    }
}
