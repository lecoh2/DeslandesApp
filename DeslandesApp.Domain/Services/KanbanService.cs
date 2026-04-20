using DeslandesApp.Domain.Helpers;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Entities;
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

        public KanbanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<KanbanColuna>> ObterKanbanAsync()
        {
            // 🔹 Busca dados do banco
            var tarefas = await _unitOfWork.TarefaRepository.GetAllAsync();
            var eventos = await _unitOfWork.EventoRepository.GetAllAsync();

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
                    Status = t.StatusGeralKanban,
                    UsuarioCriacaoId = t.UsuarioCriacaoId
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
                    Tipo = "Evento",
                    Status = e.StatusGeralKanban,
                    UsuarioCriacaoId = e.UsuarioCriacaoId
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

            if (tarefa != null)
            {
                tarefa.StatusGeralKanban = status;
                await _unitOfWork.CommitAsync();
                return;
            }

            var evento = await _unitOfWork.EventoRepository.GetByIdAsync(id);

            if (evento != null)
            {
                evento.StatusGeralKanban = status;
                await _unitOfWork.CommitAsync();
                return;
            }

            throw new Exception("Item não encontrado");
        }
    }
}
