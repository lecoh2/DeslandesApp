using AutoMapper;
using DeslandesApp.Domain.Exceptions;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.CategoriaFinanceira;
using DeslandesApp.Domain.Models.Dtos.Responses.CategoriaFinanceira;
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
    public class CategoriaFinanceiraService(
           IUnitOfWork unitOfWork,
           IMapper mapper,
           IHttpContextAccessor httpContextAccessor,
           IHistoricoGeralService historicoGeralService
       ) : BaseService(httpContextAccessor),
           ICategoriaFinanceiraService
    {
        public async Task<CategoriaFinanceiraResponse> AdicionarAsync(
            CategoriaFinanceiraRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entity =
                    mapper.Map<CategoriaFinanceira>(request);

                entity.DataCadastro = DateTime.Now;

                await unitOfWork
                    .CategoriaFinanceiraRepository
                    .AddAsync(entity);

                await unitOfWork.CommitAsync();

                return mapper.Map<CategoriaFinanceiraResponse>(
                    entity);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<CategoriaFinanceiraResponse> ModificarAsync(
            Guid id,
            CategoriaFinanceiraUpdateRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var categoria =
                    await unitOfWork
                        .CategoriaFinanceiraRepository
                        .GetByIdAsync(id);

                if (categoria == null)
                    throw new BusinessException(
                        "Categoria financeira não encontrada.");

                var usuarioId = ObterUsuarioId();

                var dadosAntes = new
                {
                    categoria.Nome,
                    categoria.Tipo
                };

                categoria.Nome = request.Nome?.Trim();

                categoria.Tipo = request.Tipo;

                categoria.DataAtualizacao =
                    DateTime.Now;

                await unitOfWork
                    .CategoriaFinanceiraRepository
                    .UpdateAsync(categoria);

                var dadosDepois = new
                {
                    categoria.Nome,
                    categoria.Tipo
                };

                await historicoGeralService.RegistrarAsync(
                    TipoEntidade.CategoriaFinanceira,
                    categoria.Id,
                    usuarioId,
                    dadosAntes,
                    dadosDepois,
                    "Categoria financeira alterada."
                );

                await unitOfWork.CommitAsync();

                return mapper.Map<CategoriaFinanceiraResponse>(
                    categoria);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<CategoriaFinanceiraResponse> ExcluirAsync(
            Guid id)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var categoria =
                    await unitOfWork
                        .CategoriaFinanceiraRepository
                        .GetByIdAsync(id);

                if (categoria == null)
                    throw new BusinessException(
                        "Categoria financeira não encontrada.");

                categoria.Excluido = true;
                categoria.DataExclusao = DateTime.Now;

                await unitOfWork
                    .CategoriaFinanceiraRepository
                    .UpdateAsync(categoria);

                await unitOfWork.CommitAsync();

                return mapper.Map<CategoriaFinanceiraResponse>(
                    categoria);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<ObterCategoriaFinanceiraResponse?>
            ObterPorIdAsync(Guid id)
        {
            var categoria =
                await unitOfWork
                    .CategoriaFinanceiraRepository
                    .ObterCompletoPorIdAsync(id);

            if (categoria == null)
                return null;

            return mapper.Map<ObterCategoriaFinanceiraResponse>(
                categoria);
        }

        public async Task<PageResult<CategoriaFinanceiraResponse>>
            ConsultarAsync(
                int pageNumber,
                int pageSize)
        {
            var result =
                await unitOfWork
                    .CategoriaFinanceiraRepository
                    .GetAllAsync(pageNumber, pageSize);

            return new PageResult<CategoriaFinanceiraResponse>
            {
                Items = mapper.Map<List<CategoriaFinanceiraResponse>>(
                    result.Items),

                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            };
        }

        public async Task<List<CategoriaFinanceiraResponse>>
            ConsultarAsync()
        {
            var result =
                await unitOfWork
                    .CategoriaFinanceiraRepository
                    .GetAllAsync();

            return mapper.Map<List<CategoriaFinanceiraResponse>>(
                result);
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
        public async Task<PageResult<CategoriaFinanceiraPaginacaoResponse>> ConsultarCategoriaFinanceiraPaginacaoAsync(
    int pageNumber,
    int pageSize,
    string? searchTerm = null)
        {
            var paged = await unitOfWork.CategoriaFinanceiraRepository
                .ConsultarCategoriaFinanceiraPaginacaoAsync(
                    pageNumber,
                    pageSize,
                    searchTerm
                );

            if (paged == null || !paged.Items.Any())
            {
                return new PageResult<CategoriaFinanceiraPaginacaoResponse>
                {
                    Items = new List<CategoriaFinanceiraPaginacaoResponse>(),
                    TotalCount = 0,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }

            return paged;
        }

    
    }
}
