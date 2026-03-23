using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Evento;
using DeslandesApp.Domain.Models.Dtos.Responses.Evento;
using DeslandesApp.Domain.Models.Dtos.Responses.Tarefa;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Domain.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class EventoService(IUnitOfWork unitOfWork, IMapper mapper) : IEventoService
    {
        public async Task<CriarEventoResponse> AdicionarAsync(CriarEventoRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            // DTO -> Entidade
            var evento = mapper.Map<Evento>(request);

            // =========================
            // ✅ STATUS (PADRÃO + AUTOMÁTICO)
            // =========================
            evento.Status = request.Status ?? StatusEvento.Agendado;

            var agora = DateTime.Now;
            var hoje = DateOnly.FromDateTime(agora);
            var horaAtual = TimeOnly.FromDateTime(agora);

            if (evento.DataFinal.HasValue && evento.DataFinal.Value < hoje)
            {
                evento.Status = StatusEvento.Concluido;
            }
            else if (evento.DataInicial == hoje &&
                     evento.HoraInicial <= horaAtual &&
                     (evento.HoraFinal == null || evento.HoraFinal >= horaAtual))
            {
                evento.Status = StatusEvento.EmAndamento;
            }

            // =========================
            // 🧹 NORMALIZAÇÃO
            // =========================
            evento.Titulo = evento.Titulo.Trim();
            evento.Endereco = evento.Endereco?.Trim();
            evento.Observacao = evento.Observacao?.Trim();

            // =========================
            // 🕒 DIA INTEIRO
            // =========================
            if (evento.DiaInteiro)
            {
                evento.HoraInicial = TimeOnly.MinValue;
                evento.HoraFinal = TimeOnly.MaxValue;
            }

            // =========================
            // 🔁 RECORRÊNCIA
            // =========================
            if (evento.IntervaloRecorrencia < 1)
                throw new InvalidOperationException("Intervalo da recorrência deve ser maior ou igual a 1.");

            if (evento.TipoRecorrencia != TipoRecorrencia.Nenhuma)
            {
                if (evento.DataFimRecorrencia.HasValue && evento.QuantidadeOcorrencias.HasValue)
                    throw new InvalidOperationException("Informe apenas DataFimRecorrencia ou QuantidadeOcorrencias.");

                if (!evento.DataFimRecorrencia.HasValue && !evento.QuantidadeOcorrencias.HasValue)
                    throw new InvalidOperationException("Recorrência precisa de um critério de término.");

                if (evento.TipoRecorrencia == TipoRecorrencia.Semanal &&
                    (evento.DiasSemana == null || !evento.DiasSemana.Any()))
                    throw new InvalidOperationException("Informe ao menos um dia da semana para recorrência semanal.");
            }
            else
            {
                evento.IntervaloRecorrencia = 1;
                evento.DiasSemana = new List<DayOfWeek>();
                evento.DataFimRecorrencia = null;
                evento.QuantidadeOcorrencias = null;
            }

            // =========================
            // ✅ VALIDAÇÃO
            // =========================
            var validator = new EventoValidator();
            var result = validator.Validate(evento);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            // =========================
            // 💾 SALVAR EVENTO
            // =========================
            await unitOfWork.EventoRepository.AddAsync(evento);

            // =========================
            // 👥 RESPONSÁVEIS (N:N)
            // =========================
            if (request.GrupoEventoResponsavel != null && request.GrupoEventoResponsavel.Any())
            {
                foreach (var envolvidos in request.GrupoEventoResponsavel)
                {
                    var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(envolvidos.UsuarioId);
                    if (usuario == null)
                        throw new InvalidOperationException("Responsável não encontrado.");

                    var grupo = new GrupoEventoResponsavel
                    {
                        EventoId = evento.Id,
                        UsuarioId = envolvidos.UsuarioId
                    };

                    await unitOfWork.GrupoEventoResponsavelRepository.AddAsync(grupo);
                }
            }

            // =========================
            // 💾 COMMIT
            // =========================
            await unitOfWork.CommitAsync();

            return mapper.Map<CriarEventoResponse>(evento);
        }

        public Task<PageResult<CriarEventoResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<CriarEventoResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CriarEventoResponse> ModificarAsync(Guid id, UpdateEventoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CriarEventoResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
