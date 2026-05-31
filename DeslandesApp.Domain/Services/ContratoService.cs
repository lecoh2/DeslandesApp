using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Contrato;
using DeslandesApp.Domain.Models.Dtos.Responses.Contrato;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using Microsoft.AspNetCore.Http;

namespace DeslandesApp.Domain.Services
{
    public class ContratoService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
    ) : BaseService(httpContextAccessor), IContratoService
    {
        public async Task<ContratoResponse> AdicionarAsync(
            ContratoRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var contrato = mapper.Map<Contrato>(request);

                contrato.DataCadastro = DateTime.Now;

                await unitOfWork.ContratoRepository
                    .AddAsync(contrato);

                await unitOfWork.CommitAsync();

                return mapper.Map<ContratoResponse>(contrato);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<ContratoResponse> ModificarAsync(
            Guid id,
            ContratoUpdateRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var contrato = await unitOfWork
                    .ContratoRepository
                    .GetByIdAsync(id);

                if (contrato == null)
                    throw new ApplicationException(
                        "Contrato não encontrado."
                    );

                mapper.Map(request, contrato);

                contrato.DataAtualizacao = DateTime.Now;

                await unitOfWork.ContratoRepository
                    .UpdateAsync(contrato);

                await unitOfWork.CommitAsync();

                return mapper.Map<ContratoResponse>(contrato);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<ContratoResponse> ExcluirAsync(Guid id)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var contrato = await unitOfWork
                    .ContratoRepository
                    .GetByIdAsync(id);

                if (contrato == null)
                    throw new ApplicationException(
                        "Contrato não encontrado."
                    );

                contrato.Excluido = true;
                contrato.DataExclusao = DateTime.Now;
                contrato.UsuarioExclusaoId = ObterUsuarioId();

                await unitOfWork.ContratoRepository
                    .UpdateAsync(contrato);

                await unitOfWork.CommitAsync();

                return mapper.Map<ContratoResponse>(contrato);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<List<ContratoResponse>> ConsultarAsync()
        {
            var contratos = await unitOfWork
                .ContratoRepository
                .GetAllAsync();

            return mapper.Map<List<ContratoResponse>>(contratos);
        }

        public async Task<PageResult<ContratoResponse>> ConsultarAsync(
            int pageNumber,
            int pageSize)
        {
            var result = await unitOfWork
                .ContratoRepository
                .GetAllAsync(pageNumber, pageSize);

            return new PageResult<ContratoResponse>
            {
                Items = mapper.Map<List<ContratoResponse>>(result.Items),
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            };
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<PageResult<ContratoPaginacaoResponse>> ConsultarContratoPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {
                  
            var paged = await unitOfWork.ContratoRepository
                .ConsultarContratoPaginacaoAsync(pageNumber, pageSize, searchTerm);

            if (paged == null || !paged.Items.Any())
            {
                return new PageResult<ContratoPaginacaoResponse>
                {
                    Items = new List<ContratoPaginacaoResponse>(),
                    TotalCount = 0,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }

            return paged;
        }
    }
    }
