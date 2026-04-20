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

        public async Task<DetalheAtividadeResponse> ObterDetalhesAsync(Guid id, string tipo)
        {
            if (tipo == "Tarefa")
            {
                var t = await _unitOfWork.TarefaRepository.GetByIdAsync(id);

                if (t == null)
                    throw new Exception("Tarefa não encontrada");

                return new DetalheAtividadeResponse(
                    t.Id,
                    t.Descricao,
                    t.StatusGeralKanban.ToString(),
                    t.DataTarefa,
                    null,
                    null,
                    null,
                    t.UsuarioCriacao?.NomeUsuario,
                    t.GrupoTarefaResponsaveis?
                        .Select(r => new UsuarioResumoResponse(
                            r.Usuario.Id,
                            r.Usuario.NomeUsuario
                        ))
                        .ToList() ?? new List<UsuarioResumoResponse>(),

                    new List<EtiquetaResponse>()
                );
            }

            var e = await _unitOfWork.EventoRepository.ConsultarEventoComRelacionamentosAsync(id);

            if (e == null)
                throw new Exception("Evento não encontrado");

            var responsaveis = e.GrupoEventoResponsaveis?
                .Select(r => new UsuarioResumoResponse(
                    r.Usuario.Id,
                    r.Usuario.NomeUsuario
                ))
                .ToList() ?? new List<UsuarioResumoResponse>();

            var etiquetas = e.GrupoEventoEtiquetas?
                .Select(x => new EtiquetaResponse(
                    x.Etiqueta.Id,
                    x.Etiqueta.Nome,
                    x.Etiqueta.Cor
                ))
                .ToList() ?? new List<EtiquetaResponse>();

            return new DetalheAtividadeResponse(
                e.Id,
                e.Titulo,
                e.StatusGeralKanban.ToString(),
                e.DataInicial.ToDateTime(TimeOnly.MinValue),
                e.DataFinal?.ToDateTime(TimeOnly.MinValue),
                e.Modalidade.ToString(),
                e.Endereco,
                e.UsuarioCriacao?.NomeUsuario,
                responsaveis,
                etiquetas
            );
        }
    }
}