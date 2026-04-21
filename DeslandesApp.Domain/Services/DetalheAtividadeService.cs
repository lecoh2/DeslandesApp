using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Responses.Atividades;
using DeslandesApp.Domain.Models.Dtos.Responses.Etiquetas;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class DetalheAtividadeService : IDetalheAtividadeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetalheAtividadeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DetalheAtividadeResponse> ObterDetalhesAsync(Guid id, TipoAtividade tipo)
        {
            return tipo switch
            {
                TipoAtividade.Tarefa => await ObterTarefaAsync(id),
                TipoAtividade.Evento => await ObterEventoAsync(id),
                _ => throw new ArgumentOutOfRangeException(nameof(tipo), "Tipo inválido")
            };
        }
        private async Task<DetalheAtividadeResponse> ObterTarefaAsync(Guid id)
        {
            var t = await _unitOfWork.TarefaRepository.ConsultarComRelacionamentosAsync(id);

            if (t == null)
                throw new KeyNotFoundException("Tarefa não encontrada");

            return new DetalheAtividadeResponse
            {
                Id = t.Id,
                Titulo = t.Descricao,
                Status = t.StatusGeralKanban.ToString(),
                DataInicio = t.DataTarefa,
                CriadoPor = t.UsuarioCriacao?.NomeUsuario,
                Prioridade = t.Prioridade,
                Tipo = TipoAtividade.Tarefa.ToString(),
                Responsaveis = t.GrupoTarefaResponsaveis?
    .Select(r => new UsuarioResumoResponse(
        r.Usuario.Id,
        r.Usuario.NomeUsuario
    ))
    .ToList() ?? new(),

                Etiquetas = t.GrupoTarefasEtiquetas?
    .Select(x => new EtiquetaResponse(
        x.Etiqueta.Id,
        x.Etiqueta.Nome,
        x.Etiqueta.Cor
    ))
    .ToList() ?? new()
            };
        }
        private async Task<DetalheAtividadeResponse> ObterEventoAsync(Guid id)
        {
            var e = await _unitOfWork.EventoRepository.ConsultarEventoComRelacionamentosAsync(id);

            if (e == null)
                throw new KeyNotFoundException("Evento não encontrado");

            return new DetalheAtividadeResponse
            {
                Id = e.Id,
                Titulo = e.Titulo,
                Status = e.StatusGeralKanban.ToString(),
                DataInicio = e.DataInicial.ToDateTime(TimeOnly.MinValue),
                DataFim = e.DataFinal?.ToDateTime(TimeOnly.MinValue),
                Modalidade = e.Modalidade.ToString(),
                Endereco = e.Endereco,
               
                CriadoPor = e.UsuarioCriacao?.NomeUsuario,
                Tipo = TipoAtividade.Evento.ToString(),
                Responsaveis = e.GrupoEventoResponsaveis?
                    .Select(r => new UsuarioResumoResponse(
                        r.Usuario.Id,
                        r.Usuario.NomeUsuario
                    ))
                    .ToList() ?? new(),
                Etiquetas = e.GrupoEventoEtiquetas?
                    .Select(x => new EtiquetaResponse(
                        x.Etiqueta.Id,
                        x.Etiqueta.Nome,
                        x.Etiqueta.Cor
                    ))
                    .ToList() ?? new()
            };
        }
    }
}