using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Lembrete;
using DeslandesApp.Domain.Models.Dtos.Responses.lembretes;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class LembreteService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        : BaseService(httpContextAccessor),ILembreteService
    {
        public Task<LembreteResponse> AdicionarAsync(LembreteRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<LembreteResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<LembreteResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LembreteResponse> ModificarAsync(Guid id, LembreteUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LembreteResponse>> ObterLembretesAsync()
        {
            var hoje = DateTime.Today;
            var amanha = hoje.AddDays(1);

            //
            // ============================
            // USUÁRIO LOGADO
            // ============================
            //
            var usuarioId = ObterUsuarioId();

            if (!usuarioId.HasValue)
            {
                throw new ApplicationException("Usuário não identificado.");
            }

            //
            // ============================
            // BUSCA USUÁRIO NO BANCO (CORRETO)
            // ============================
            //
            var usuario = await unitOfWork.UsuarioRepository
      .ObterComNiveisAsync(usuarioId.Value);

            if (usuario == null)
            {
                throw new ApplicationException("Usuário não encontrado.");
            }

            //
            // ============================
            // ADMINISTRADOR (CORRETO)
            // ============================
            //
            var isAdministrador =
             usuario.GrupoNiveis
                 .Any(x =>
                     x.Niveis != null &&
                     string.Equals(
                         x.Niveis.NomeNivel,
                         "Administrador",
                         StringComparison.OrdinalIgnoreCase
                     )
                 );

            //
            // ============================
            // TAREFAS
            // ============================
            //
            var tarefas =
                await unitOfWork
                    .TarefaRepository
                    .ObterTarefasLembreteAsync(
                        usuarioId.Value,
                        isAdministrador
                    );

            //
            // ============================
            // EVENTOS
            // ============================
            //
            var eventos =
                await unitOfWork
                    .EventoRepository
                    .ObterEventosLembreteAsync(
                        usuarioId.Value,
                        isAdministrador
                    );

            //
            // ============================
            // MAP TAREFAS
            // ============================
            //
            var listaTarefas = tarefas
                .Where(t => t.DataTarefa.HasValue)
                .Select(t => new LembreteResponse
                {
                    Id = t.Id,
                    Titulo = t.Descricao,
                    Data = t.DataTarefa!.Value,
                    Tipo = "Tarefa",

                    Responsaveis = t.GrupoTarefaResponsaveis
                        .Where(r => r.Usuario != null)
                        .Select(r => r.Usuario!.NomeUsuario)
                        .Distinct()
                        .ToList()
                });

            //
            // ============================
            // MAP EVENTOS
            // ============================
            //
            var listaEventos = eventos
                .Select(e => new LembreteResponse
                {
                    Id = e.Id,
                    Titulo = e.Titulo,
                    Data = e.DataInicial.ToDateTime(e.HoraInicial),
                    Tipo = "Evento",

                    Recorrente =
                        e.TipoRecorrencia != TipoRecorrencia.Nenhuma,

                    DiaInteiro = e.DiaInteiro,

                    Responsaveis = e.GrupoEventoResponsaveis
                        .Where(r => r.Usuario != null)
                        .Select(r => r.Usuario!.NomeUsuario)
                        .Distinct()
                        .ToList()
                });

            //
            // ============================
            // JUNTA + ORDENA
            // ============================
            //
            var resultado = listaTarefas
                .Concat(listaEventos)
                .OrderBy(x => x.Data)
                .Take(5)
                .ToList();

            //
            // ============================
            // CATEGORIA
            // ============================
            //
            foreach (var item in resultado)
            {
                if (item.Data.Date == hoje.Date)
                {
                    item.Categoria = "Hoje";
                }
                else if (item.Data.Date == amanha.Date)
                {
                    item.Categoria = "Amanhã";
                }
                else
                {
                    item.Categoria = "Próximos";
                }
            }

            return resultado;
        }
    }
}
