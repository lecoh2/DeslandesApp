using AutoMapper;
using DeslandesApp.Domain.Exceptions;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta.DeslandesApp.Domain.Models.Dtos.Responses.Conta;
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


        public async Task BaixarAsync(
          Guid id,
          ContaPagarBaixaRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var conta = await unitOfWork
                    .ContaPagarRepository
                    .GetByIdAsync(id);

                if (conta == null)
                {
                    throw new BusinessException(
                        "Conta não encontrada."
                    );
                }

                if (conta.Parcelado &&
                    conta.NumeroParcela == 0)
                {
                    throw new BusinessException(
                        "Realize a baixa diretamente na parcela."
                    );
                }

                if (request.ValorPago <= 0)
                {
                    throw new BusinessException(
                        "O valor da baixa deve ser maior que zero."
                    );
                }

                var saldo = conta.Valor - conta.ValorPago;

                if (request.ValorPago > saldo)
                {
                    throw new BusinessException(
                        $"O valor informado é maior que o saldo da conta. Saldo atual: {saldo:C2}"
                    );
                }

                var baixa = new BaixaFinanceira
                {
                    Id = Guid.NewGuid(),
                    ContaPagarId = conta.Id,
                    ValorPago = request.ValorPago,
                    DataBaixa = request.DataBaixa,
                    Observacao = request.Observacao,
                    FormaRecebimento = request.FormaRecebimento,
                    ContaBancariaEmpresaId = request.ContaBancariaEmpresaId
                };

                await unitOfWork
                    .BaixaFinanceiraRepository
                    .AddAsync(baixa);

                conta.ValorPago += request.ValorPago;

                if (conta.ValorPago >= conta.Valor)
                {
                    conta.Status = StatusConta.Paga;
                    conta.Quitado = true;
                    conta.DataQuitacao = DateTime.Now;
                }
                else if (conta.ValorPago > 0)
                {
                    conta.Status = StatusConta.ParcialmentePaga;
                    conta.Quitado = false;
                    conta.DataQuitacao = null;
                }
                else
                {
                    conta.Status = StatusConta.Aberta;
                    conta.Quitado = false;
                    conta.DataQuitacao = null;
                }

                conta.DataAtualizacao = DateTime.Now;

                await unitOfWork
                    .ContaPagarRepository
                    .UpdateAsync(conta);

                // Atualiza conta agrupadora
                if (conta.ContaPaiId.HasValue)
                {
                    var contaPai = await unitOfWork
                        .ContaPagarRepository
                        .ObterCompletoPorIdAsync(
                            conta.ContaPaiId.Value);

                    if (contaPai != null)
                    {
                        var parcelas = contaPai.Parcelas.ToList();

                        var valorPagoPai =
                            parcelas.Sum(x => x.ValorPago);

                        var todasPagas = parcelas.All(x =>
                            x.Status == StatusConta.Paga);

                        var algumaPaga = parcelas.Any(x =>
                            x.ValorPago > 0);

                        var statusPai = StatusConta.Aberta;
                        var quitadoPai = false;
                        DateTime? dataQuitacaoPai = null;

                        if (todasPagas)
                        {
                            statusPai = StatusConta.Paga;
                            quitadoPai = true;
                            dataQuitacaoPai = DateTime.Now;
                        }
                        else if (algumaPaga)
                        {
                            statusPai = StatusConta.ParcialmentePaga;
                        }

                        await unitOfWork
                            .ContaPagarRepository
                            .AtualizarContaPaiAsync(
                                contaPai.Id,
                                valorPagoPai,
                                statusPai,
                                quitadoPai,
                                dataQuitacaoPai
                            );
                    }
                }

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<List<ContaPagarResponse>> ConsultarAsync()
        {
            var list = await unitOfWork.ContaReceberRepository
                .ConsultarComRelacionamentosAsync();

            return mapper.Map<List<ContaPagarResponse>>(list);       }

        public Task<PageResult<ContaPagarResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<ContaPagarConsultaResponse>>
        ConsultarPaginacaoAsync(
            int pageNumber,
            int pageSize)
        {
            var result = await unitOfWork
                .ContaPagarRepository
                .GetPaginacaoAsync(
                    pageNumber,
                    pageSize
                );

            return new PageResult<ContaPagarConsultaResponse>
            {
                Items = result.Items,
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

        public async Task<ObterContaPagarResponse?> ObterPorIdAsync(Guid id)
        {
            var contaPagar = await unitOfWork
                .ContaPagarRepository
                .ObterCompletoPorIdAsync(id);

            if (contaPagar == null)
                return null;

            return mapper.Map<ObterContaPagarResponse>(contaPagar);
        }
    }
}
