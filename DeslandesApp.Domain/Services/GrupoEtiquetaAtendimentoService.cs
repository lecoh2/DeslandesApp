using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiquetaProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaAtendimento;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class GrupoEtiquetaAtendimentoService(IUnitOfWork unitOfWork, IMapper mapper) : IGrupoEtiquetaAtendimentoServices
    {
        public Task<GrupoEtiquetaAtendimentoResponse> AdicionarAsync(GrupoEtiquetaAtendimentoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoEtiquetaAtendimentoResponse> AdicionarEtiquetaAtendimentoAsync(Guid idEtiqueta, Guid idAtendimento)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var etiqueta = await unitOfWork.EtiquetaRepository.GetByIdAsync(idEtiqueta);
                if (etiqueta is null)
                    throw new ApplicationException("Etiquta não encontrado.");

                var atendimento = await unitOfWork.AtendimentoRepository.GetByIdAsync(idAtendimento);
                if (atendimento is null)
                    throw new ApplicationException("Processo não encontrado.");

                var existeVinculo = await unitOfWork.GrupoEtiquetasAtendimentoRepository
                    .ExistEtiquetaAtendimentoAsync(idEtiqueta, idAtendimento);

                if (existeVinculo != null)
                    throw new ApplicationException("Este usuário já está vinculado a esse setor.");

                var grupoEtiquetaAtendimento = new GrupoEtiquetasAtendimentos
                {
                    EtiquetaId = idEtiqueta,
                    AtendimentoId = idAtendimento
                };

                await unitOfWork.GrupoEtiquetasAtendimentoRepository.AddAsync(grupoEtiquetaAtendimento);

                await unitOfWork.CommitAsync();

                return new GrupoEtiquetaAtendimentoResponse
                {
                    EtiquetaId = etiqueta.Id,
                    Nome = etiqueta.Nome
                };
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }


        public Task<PageResult<GrupoEtiquetaAtendimentoResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<GrupoEtiquetaAtendimentoResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoEtiquetaAtendimentoResponse> ModificarAsync(Guid id, GrupoEtiquetaAtendimentoUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoEtiquetaAtendimentoResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoEtiquetaAtendimentoResponse> RemoverEtiquetaAtendimentoAsync(Guid idEtiqueta, Guid idAtendimento)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entidade = await unitOfWork.GrupoEtiquetasAtendimentoRepository
                    .GetByIdEtiquetaAtendimentoAsync(idEtiqueta, idAtendimento);

                if (entidade is null)
                    throw new Exception("Vínculo entre Processo e Etiqueta não encontrado.");

                await unitOfWork.GrupoEtiquetasAtendimentoRepository.DeleteAsync(entidade);

                await unitOfWork.CommitAsync();
                return new GrupoEtiquetaAtendimentoResponse
                {
                    EtiquetaId = entidade.EtiquetaId,
                    Nome = entidade.Etiqueta?.Nome
                };
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw; // 🔥 ESSENCIAL pro middleware funcionar
            }
        }
    }
}
