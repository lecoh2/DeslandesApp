using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiquetaProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEnvolvidosProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetasProcessos;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class GrupoEtiquetasProcessosService(IUnitOfWork unitOfWork, IMapper mapper) : IGrupoEtiquetaProcessoService
    {
        public Task<GrupoEtiquetasProcessosResponse> AdicionarAsync(GrupoEtiquetaProcessoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoEtiquetasProcessosResponse> AdicionarEtiquetaProcessoAsync(Guid idEtiqueta, Guid idProcesso)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var etiqueta = await unitOfWork.EtiquetaRepository.GetByIdAsync(idEtiqueta);
                if (etiqueta is null)
                    throw new ApplicationException("Etiquta não encontrado.");

                var processo = await unitOfWork.ProcessoRepository.GetByIdAsync(idProcesso);
                if (processo is null)
                    throw new ApplicationException("Processo não encontrado.");

                var existeVinculo = await unitOfWork.GrupoEtiquetasProcessosRepository
                    .ExistEtiquetaProcessoAsync(idEtiqueta, idProcesso);

                if (existeVinculo != null)
                    throw new ApplicationException("Este usuário já está vinculado a esse setor.");

                var grupoEtiquetaProcesso = new GrupoEtiquetasProcessos
                {
                    EtiquetaId = idEtiqueta,
                    ProcessoId = idProcesso
                };

                await unitOfWork.GrupoEtiquetasProcessosRepository.AddAsync(grupoEtiquetaProcesso);

                await unitOfWork.CommitAsync();

                return new GrupoEtiquetasProcessosResponse(
                   etiqueta.Id,
                   processo.Id,
                   etiqueta.Nome // 👈 aqui

               );
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task<PageResult<GrupoEtiquetasProcessosResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<GrupoEtiquetasProcessosResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoEtiquetasProcessosResponse> ModificarAsync(Guid id, GrupoEtiquetaProcessoUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoEtiquetasProcessosResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoverEtiquetaProcessoAsync(Guid idEtiqueta, Guid idProcesso)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entidade = await unitOfWork.GrupoEtiquetasProcessosRepository
                    .GetByIdEtiquetaProcessoAsync(idEtiqueta, idProcesso);

                if (entidade is null)
                    throw new Exception("Vínculo entre Processo e Etiqueta não encontrado.");

                await unitOfWork.GrupoEtiquetasProcessosRepository.DeleteAsync(entidade);

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw; // 🔥 ESSENCIAL pro middleware funcionar
            }

        }

    }
}
