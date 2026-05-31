using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class ContaReceberService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
    ) : BaseService(httpContextAccessor), IContaReceberService
    {
        public async Task<ContaReceberResponse> AdicionarAsync(ContaReceberRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var conta = mapper.Map<ContaReceber>(request);

                conta.PessoaId = request.PessoaId;
                conta.ContratoId = request.ContratoId.Value;

                conta.Status = StatusConta.Aberta;
                conta.ValorPago = 0;
                conta.DataCadastro = DateTime.Now;

                await unitOfWork.ContaReceberRepository.AddAsync(conta);

                await unitOfWork.CommitAsync();

                return mapper.Map<ContaReceberResponse>(conta);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task<ContaReceberResponse> ModificarAsync(Guid id, ContaReceberUpdateRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var conta = await unitOfWork.ContaReceberRepository.GetByIdAsync(id);

                if (conta == null)
                    throw new ApplicationException("Conta não encontrada.");

                mapper.Map(request, conta);

                conta.DataAtualizacao = DateTime.Now;

                await unitOfWork.ContaReceberRepository.UpdateAsync(conta);

                await unitOfWork.CommitAsync();

                return mapper.Map<ContaReceberResponse>(conta);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task<ContaReceberResponse> ExcluirAsync(Guid id)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var conta = await unitOfWork.ContaReceberRepository.GetByIdAsync(id);

                if (conta == null)
                    throw new ApplicationException("Conta não encontrada.");

                conta.Excluido = true;
                conta.DataExclusao = DateTime.Now;
                conta.UsuarioExclusaoId = ObterUsuarioId();

                await unitOfWork.ContaReceberRepository.UpdateAsync(conta);

                await unitOfWork.CommitAsync();

                return mapper.Map<ContaReceberResponse>(conta);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task BaixarAsync(Guid id, ContaReceberBaixaRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var conta = await unitOfWork.ContaReceberRepository.GetByIdAsync(id);

                if (conta == null)
                    throw new ApplicationException("Conta não encontrada.");

                conta.ValorPago += request.ValorPago;

                conta.Status =
                    conta.ValorPago >= conta.Valor
                        ? StatusConta.Paga
                        : StatusConta.ParcialmentePaga;

                conta.DataAtualizacao = DateTime.Now;

                await unitOfWork.ContaReceberRepository.UpdateAsync(conta);

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task<PageResult<ContaReceberResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            var result = await unitOfWork.ContaReceberRepository
                .GetPaginacaoAsync(pageNumber, pageSize);

            return new PageResult<ContaReceberResponse>
            {
                Items = mapper.Map<List<ContaReceberResponse>>(result.Items),
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            };
        }
        public async Task<List<ContaReceberResponse>> ConsultarAsync()
        {
            var list = await unitOfWork.ContaReceberRepository
                .ConsultarComRelacionamentosAsync();

            return mapper.Map<List<ContaReceberResponse>>(list);
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}