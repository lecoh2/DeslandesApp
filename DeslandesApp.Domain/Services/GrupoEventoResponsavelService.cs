using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoClienteProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEventoResponsavel;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class GrupoEventoResponsavelService(IUnitOfWork unitOfWork, IMapper mapper) : IGrupoEventoResponsaveisService
    {
        public Task<GrupoEventoResponsavelResponse> AdicionarAsync(GrupoEventoResponsavelRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoEventoResponsavelResponse> AdicionarEventoResponsaveisAsync(Guid idEvento, Guid idUsuario)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(idUsuario);
                if (usuario is null)
                    throw new ApplicationException("Usuario não encontrada.");

                var evento = await unitOfWork.EventoRepository.GetByIdAsync(idEvento);
                if (evento is null)
                    throw new ApplicationException("Evento não encontrado.");

                var existeVinculo = await unitOfWork.GrupoEventoResponsavelRepository
                    .ExistEventoResponsaveisAsync(idEvento, idUsuario);

                if (existeVinculo != null)
                    throw new ApplicationException("Este usuário já está vinculado a esse Evento.");

                var grupoEventoResponsavel = new GrupoEventoResponsavel
                {
                    EventoId = idEvento,
                    UsuarioId = idUsuario
                };

                await unitOfWork.GrupoEventoResponsavelRepository.AddAsync(grupoEventoResponsavel);

                await unitOfWork.CommitAsync();

                return new GrupoEventoResponsavelResponse(
                    usuario.Id,
                     usuario.NomeUsuario
                //pessoa.Nome // 👈 aqui

                );
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task<PageResult<GrupoEventoResponsavelResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<GrupoEventoResponsavelResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoEventoResponsavelResponse> ModificarAsync(Guid id, GrupoEventoResponsavelUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoEventoResponsavelResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoEventoResponsavelResponse> RemoverGrupoEventoResponsaveisAsync(Guid idEvento, Guid idUsuario)
        {

            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entidade = await unitOfWork.GrupoEventoResponsavelRepository
                    .GetByIdEventoResponsaveisAsync(idEvento, idUsuario);

                if (entidade is null)
                    throw new Exception("Vínculo entre evento e usuário não encontrado.");

                await unitOfWork.GrupoEventoResponsavelRepository.DeleteAsync(entidade);

                await unitOfWork.CommitAsync();
                return new GrupoEventoResponsavelResponse(
             entidade.UsuarioId,
           entidade.Usuario?.NomeUsuario ?? string.Empty
);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw; // 🔥 ESSENCIAL pro middleware funcionar
            }
        }
    }
}
