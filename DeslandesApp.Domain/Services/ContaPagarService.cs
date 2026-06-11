using AutoMapper;
using DeslandesApp.Domain.Exceptions;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class ContaPagarService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor, IHistoricoGeralService historicoGeralService
    ) : BaseService(httpContextAccessor), IContaPagarService
    {
        public async Task<ContaPagarResponse> AdicionarAsync(ContaPagarRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                // =========================
                // VALIDAÇÕES (IGUAL RECEBER)
                // =========================
                if (request.Valor <= 0)
                    throw new BusinessException("O valor deve ser maior que zero.");

                if (string.IsNullOrWhiteSpace(request.Descricao))
                    throw new BusinessException("Descrição é obrigatória.");

                if (request.PessoaId == Guid.Empty)
                    throw new BusinessException("Fornecedor inválido.");

                // =========================
                // MAPEAMENTO
                // =========================
                var conta = mapper.Map<ContaPagar>(request);

                // =========================
                // PADRÃO DE CRIAÇÃO
                // =========================
                conta.Status = StatusConta.Aberta;
                conta.ValorPago = 0;
                conta.DataCadastro = DateTime.Now;
                conta.DataAtualizacao = DateTime.Now;
                // =========================
                // SALVAR
                // =========================
                await unitOfWork.ContaPagarRepository.AddAsync(conta);

                await unitOfWork.CommitAsync();

                return mapper.Map<ContaPagarResponse>(conta);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }



        public async Task BaixarAsync(Guid id, decimal valorPago)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var conta = await unitOfWork.ContaPagarRepository.GetByIdAsync(id);

                if (conta == null)
                    throw new BusinessException("Conta não encontrada.");

                if (valorPago <= 0)
                    throw new BusinessException("Valor inválido.");

                var saldo = conta.Valor - conta.ValorPago;

                if (valorPago > saldo)
                    throw new BusinessException($"Valor maior que o saldo. Saldo: {saldo:C2}");

                conta.ValorPago += valorPago;
                conta.DataAtualizacao = DateTime.Now;
                // =========================
                // STATUS PADRÃO IGUAL RECEBER
                // =========================
                if (conta.ValorPago >= conta.Valor)
                    conta.Status = StatusConta.Paga;
                else if (conta.ValorPago > 0)
                    conta.Status = StatusConta.ParcialmentePaga;
                else
                    conta.Status = StatusConta.Aberta;

                await unitOfWork.ContaPagarRepository.UpdateAsync(conta);

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task BaixarAsync(Guid id, ContaPagarUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContaPagarResponse>> ConsultarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<ContaPagarResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            var result = await unitOfWork.ContaPagarRepository
                .GetPaginacaoAsync(pageNumber, pageSize);

            return new PageResult<ContaPagarResponse>
            {
                Items = mapper.Map<List<ContaPagarResponse>>(result.Items),
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            };
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<ContaPagarResponse> ExcluirAsync(Guid id)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var conta = await unitOfWork.ContaPagarRepository.GetByIdAsync(id);

                if (conta == null)
                    throw new BusinessException("Conta não encontrada.");

                if (conta.ValorPago > 0)
                    throw new BusinessException("Não é possível excluir conta com pagamentos.");

                conta.Excluido = true;
                conta.DataExclusao = DateTime.Now;
                conta.DataAtualizacao = DateTime.Now;
                await unitOfWork.ContaPagarRepository.UpdateAsync(conta);

                await unitOfWork.CommitAsync();

                return mapper.Map<ContaPagarResponse>(conta);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<ContaPagarResponse> ModificarAsync(Guid id, ContaPagarUpdateRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var conta = await unitOfWork.ContaPagarRepository.GetByIdAsync(id);

                if (conta == null)
                    throw new BusinessException("Conta não encontrada.");

                if (conta.ValorPago > 0)
                    throw new BusinessException("Não é possível alterar conta com pagamentos.");

                var dadosAntes = new
                {
                    conta.Descricao,
                    conta.Valor,
                    conta.DataVencimento,
                    conta.PessoaId,
                    conta.CategoriaFinanceiraId
                };

                conta.Descricao = request.Descricao?.Trim();
                conta.Valor = request.Valor;
                conta.DataVencimento = request.DataVencimento;
                conta.PessoaId = request.PessoaId;
                conta.CategoriaFinanceiraId = request.CategoriaFinanceiraId;
                conta.DataAtualizacao = DateTime.Now;

                await unitOfWork.ContaPagarRepository.UpdateAsync(conta);

                var dadosDepois = new
                {
                    conta.Descricao,
                    conta.Valor,
                    conta.DataVencimento,
                    conta.PessoaId,
                    conta.CategoriaFinanceiraId
                };
                await historicoGeralService.RegistrarAsync(
    TipoEntidade.ContaPagar,
    conta.Id,
    ObterUsuarioId(),
    dadosAntes,
    dadosDepois,
    "Conta a pagar alterada."
);
                await unitOfWork.CommitAsync();

                return mapper.Map<ContaPagarResponse>(conta);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
