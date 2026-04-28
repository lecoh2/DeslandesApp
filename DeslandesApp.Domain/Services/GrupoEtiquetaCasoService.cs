using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiquetaCaso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaAtendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaCaso;
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
    public class GrupoEtiquetaCasoService(IUnitOfWork unitOfWork, IMapper mapper) : IGrupoEtiquetaCasoService
    {
        public Task<GrupoEtiquetaCasoResponse> AdicionarAsync(GrupoEtiquetaCasoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoEtiquetaCasoResponse> AdicionarEtiquetaCasoAsync(Guid idEtiqueta, Guid idCaso)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var etiqueta = await unitOfWork.EtiquetaRepository.GetByIdAsync(idEtiqueta);
                if (etiqueta is null)
                    throw new ApplicationException("Etiquta não encontrado.");

                var caso = await unitOfWork.CasoRepository.GetByIdAsync(idCaso);
                if (caso is null)
                    throw new ApplicationException("Caso não encontrado.");

                var existeVinculo = await unitOfWork.GrupoEtiquetaCasoRepository
                    .ExistEtiquetaCasoAsync(idEtiqueta, idCaso);

                if (existeVinculo != null)
                    throw new ApplicationException("Este usuário já está vinculado a esse setor.");

                var grupoEtiquetaCaso = new GrupoEtiquetaCasos
                {
                    EtiquetaId = idEtiqueta,
                    CasoId = idCaso
                };

                await unitOfWork.GrupoEtiquetaCasoRepository.AddAsync(grupoEtiquetaCaso);

                await unitOfWork.CommitAsync();

                return new GrupoEtiquetaCasoResponse
                {
                    EtiquetaId = etiqueta.Id,
                    Nome = etiqueta.Nome,
                    Cor = etiqueta.Cor
                };
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        

        public Task<PageResult<GrupoEtiquetaCasoResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<GrupoEtiquetaCasoResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoEtiquetaCasoResponse> ModificarAsync(Guid id, GrupoEtiquetaCasoUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoEtiquetaCasoResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoEtiquetaCasoResponse> RemoverEtiquetaCasoAsync(Guid idEtiqueta, Guid idCaso)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entidade = await unitOfWork.GrupoEtiquetasAtendimentoRepository
                    .GetByIdEtiquetaAtendimentoAsync(idEtiqueta, idCaso);

                if (entidade is null)
                    throw new Exception("Vínculo entre Processo e Etiqueta não encontrado.");

                await unitOfWork.GrupoEtiquetasAtendimentoRepository.DeleteAsync(entidade);

                await unitOfWork.CommitAsync();
                return new GrupoEtiquetaCasoResponse
                {
                    EtiquetaId = entidade.EtiquetaId,
                    Nome = entidade.Etiqueta?.Nome ?? string.Empty,
                    Cor = entidade.Etiqueta?.Cor ?? string.Empty
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
