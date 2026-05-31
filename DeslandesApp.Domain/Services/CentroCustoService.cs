using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.CentroCusto;
using DeslandesApp.Domain.Models.Dtos.Responses.CentroCusto;
using DeslandesApp.Domain.Models.Entities;
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
       IHttpContextAccessor httpContextAccessor
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

        public async Task<CentroCustoResponse> ModificarAsync(Guid id, CentroCustoUpdateRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entity = await unitOfWork.CentroCustoRepository.GetByIdAsync(id);

                if (entity == null)
                    throw new ApplicationException("Centro de custo não encontrado.");

                mapper.Map(request, entity);

                entity.DataAtualizacao = DateTime.Now;

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
