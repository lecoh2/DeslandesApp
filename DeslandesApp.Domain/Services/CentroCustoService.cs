using AutoMapper;
using DeslandesApp.Domain.Exceptions;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.CentroCusto;
using DeslandesApp.Domain.Models.Dtos.Responses.CentroCusto;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Entities;
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
    public class CentroCustoService(
       IUnitOfWork unitOfWork,
       IMapper mapper,
       IHttpContextAccessor httpContextAccessor, IHistoricoGeralService historicoGeralService
   ) : BaseService(httpContextAccessor), ICentroCustoService
    {
        public async Task<CentroCustoResponse> AdicionarAsync(CentroCustoRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entity = mapper.Map<CentroCusto>(request);

                entity.DataCadastro = DateTime.Now;

                await unitOfWork.CentroCustoRepository.AddAsync(entity);

                await unitOfWork.CommitAsync();

                return mapper.Map<CentroCustoResponse>(entity);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<CentroCustoResponse> ModificarAsync(
     Guid id,
     CentroCustoUpdateRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var centroCusto = await unitOfWork
                    .CentroCustoRepository
                    .GetByIdAsync(id);

                if (centroCusto == null)
                    throw new BusinessException(
                        "Centro de custo não encontrado."
                    );

                var usuarioId = ObterUsuarioId();

                // =========================
                // SNAPSHOT ANTES
                // =========================
                var dadosAntes = new
                {
                    centroCusto.Nome,
                    centroCusto.Descricao,
                    centroCusto.Ativo
                };

                // =========================
                // ATUALIZAÇÃO
                // =========================
                centroCusto.Nome = request.Nome
                    ?.Trim()
                    ?.ToUpper();

                centroCusto.Descricao = request.Descricao
                    ?.Trim();

                // Atualiza o status conforme enviado pelo frontend
                centroCusto.Ativo = request.Ativo;

                centroCusto.DataAtualizacao = DateTime.Now;

                // =========================
                // UPDATE
                // =========================
                await unitOfWork
                    .CentroCustoRepository
                    .UpdateAsync(centroCusto);

                // =========================
                // SNAPSHOT DEPOIS
                // =========================
                var dadosDepois = new
                {
                    centroCusto.Nome,
                    centroCusto.Descricao,
                    centroCusto.Ativo
                };

                // =========================
                // HISTÓRICO
                // =========================
                await historicoGeralService.RegistrarAsync(
                    TipoEntidade.CentroCusto,
                    centroCusto.Id,
                    usuarioId,
                    dadosAntes,
                    dadosDepois,
                    $"Centro de custo alterado. Status: {(centroCusto.Ativo ? "Ativo" : "Inativo")}"
                );

                // =========================
                // COMMIT
                // =========================
                await unitOfWork.CommitAsync();

                return mapper.Map<CentroCustoResponse>(
                    centroCusto
                );
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task<CentroCustoResponse> ExcluirAsync(Guid id)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entity = await unitOfWork.CentroCustoRepository.GetByIdAsync(id);

                if (entity == null)
                    throw new ApplicationException("Centro de custo não encontrado.");

                entity.Excluido = true;
                entity.DataExclusao = DateTime.Now;

                await unitOfWork.CentroCustoRepository.UpdateAsync(entity);

                await unitOfWork.CommitAsync();

                return mapper.Map<CentroCustoResponse>(entity);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task<ObterCentroCustoResponse?> ObterPorIdAsync(Guid id)
        {
            var centroCusto = await unitOfWork.CentroCustoRepository.ObterCompletoPorIdAsync(id);

            if (centroCusto == null)
                return null;

            return mapper.Map<ObterCentroCustoResponse>(centroCusto);
        }
        public async Task<PageResult<CentroCustoResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            var result = await unitOfWork.CentroCustoRepository
                .GetAllAsync(pageNumber, pageSize);

            return new PageResult<CentroCustoResponse>
            {
                Items = mapper.Map<List<CentroCustoResponse>>(result.Items),
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            };
        }

        public async Task<List<CentroCustoResponse>> ConsultarAsync()
        {
            var list = await unitOfWork.CentroCustoRepository.GetAllAsync();

            return mapper.Map<List<CentroCustoResponse>>(list);
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
