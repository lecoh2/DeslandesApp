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
                // VALIDAÇÕES
                // =========================
                if (request.Valor <= 0)
                    throw new BusinessException("O valor deve ser maior que zero.");

                if (string.IsNullOrWhiteSpace(request.Descricao))
                    throw new BusinessException("Descrição é obrigatória.");

                if (request.PessoaId == Guid.Empty)
                    throw new BusinessException("Fornecedor inválido.");

                if (request.ContratoId.HasValue)
                {
                    var duplicado = await unitOfWork.ContaPagarRepository
                        .ExisteDuplicidadeAsync(
                            request.ContratoId.Value,
                            request.Descricao,
                            request.Valor,
                            request.DataVencimento);

                    if (duplicado)
                        throw new BusinessException("Conta já cadastrada com esses dados.");
                }

                // =========================
                // 🟢 CONTA À VISTA
                // =========================
                if (!request.Parcelado)
                {
                    var conta = mapper.Map<ContaPagar>(request);

                    conta.Status = StatusConta.Aberta;
                    conta.ValorPago = 0;
                    conta.DataCadastro = DateTime.Now;
                    conta.DataAtualizacao = DateTime.Now;

                    conta.Parcelado = false;
                    conta.NumeroParcela = 1;
                    conta.TotalParcelas = 1;
                    conta.ContaPaiId = null;

                    await unitOfWork.ContaPagarRepository.AddAsync(conta);

                    await unitOfWork.CommitAsync();

                    return mapper.Map<ContaPagarResponse>(conta);
                }

                // =========================
                // 🔵 CONTA PARCELADA
                // =========================
                int totalParcelas = request.QuantidadeParcelas!.Value;

                decimal valorParcela = Math.Round(
                    request.Valor / totalParcelas,
                    2,
                    MidpointRounding.AwayFromZero
                );

                decimal valorRestante = request.Valor;

                // =========================
                // 1. CONTA PAI
                // =========================
                var contaPai = mapper.Map<ContaPagar>(request);

                contaPai.Status = StatusConta.Aberta;
                contaPai.ValorPago = 0;
                contaPai.DataCadastro = DateTime.Now;
                contaPai.DataAtualizacao = DateTime.Now;

                contaPai.Parcelado = true;
                contaPai.NumeroParcela = 0;
                contaPai.TotalParcelas = totalParcelas;
                contaPai.ContaPaiId = null;

                await unitOfWork.ContaPagarRepository.AddAsync(contaPai);

                Guid grupoId = contaPai.Id;

                // =========================
                // 2. PARCELAS
                // =========================
                ContaPagar? primeiraParcela = null;

                for (int i = 1; i <= totalParcelas; i++)
                {
                    var parcela = mapper.Map<ContaPagar>(request);

                    parcela.Status = StatusConta.Aberta;
                    parcela.ValorPago = 0;
                    parcela.DataCadastro = DateTime.Now;
                    parcela.DataAtualizacao = DateTime.Now;

                    parcela.Parcelado = true;
                    parcela.NumeroParcela = i;
                    parcela.TotalParcelas = totalParcelas;
                    parcela.ContaPaiId = grupoId;

                    parcela.DataVencimento =
                        request.DataVencimento.AddMonths(i - 1);

                    if (i == totalParcelas)
                        parcela.Valor = valorRestante;
                    else
                    {
                        parcela.Valor = valorParcela;
                        valorRestante -= valorParcela;
                    }

                    await unitOfWork.ContaPagarRepository.AddAsync(parcela);

                    if (i == 1)
                        primeiraParcela = parcela;
                }

                // =========================
                // COMMIT FINAL (ÚNICO)
                // =========================
                await unitOfWork.CommitAsync();

                return mapper.Map<ContaPagarResponse>(contaPai);
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
