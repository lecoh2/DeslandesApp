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
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class ContaReceberService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor, IHistoricoGeralService historicoGeralService
    ) : BaseService(httpContextAccessor), IContaReceberService
    {
        public async Task<ContaReceberResponse> AdicionarAsync(ContaReceberRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                if (request.Valor <= 0)
                    throw new BusinessException("O valor deve ser maior que zero.");

                if (request.Parcelado)
                {
                    if (!request.QuantidadeParcelas.HasValue || request.QuantidadeParcelas <= 1)
                        throw new BusinessException("Informe uma quantidade válida de parcelas.");
                }

                // Evita cadastro exatamente igual
                if (request.ContratoId.HasValue)
                {
                    var existeDuplicidade =
                        await unitOfWork
                            .ContaReceberRepository
                            .ExisteDuplicidadeAsync(
                                request.ContratoId.Value,
                                request.Descricao,
                                request.Valor,
                                request.DataVencimento);

                    if (existeDuplicidade)
                    {
                        throw new BusinessException(
                            "Já existe uma conta a receber com os mesmos dados para este contrato."
                        );
                    }
                }
                // =========================
                // CONTA À VISTA
                // =========================
                if (!request.Parcelado)
                {
                    var conta = mapper.Map<ContaReceber>(request);

                    conta.Status = StatusConta.Aberta;
                    conta.ValorPago = 0;
                    conta.DataCadastro = DateTime.Now;
                    conta.DataEmissao = DateTime.Now;
                    conta.TipoConta = request.TipoConta;
                    conta.FormaRecebimento = request.FormaRecebimento;

                    conta.NumeroParcela = 1;
                    conta.TotalParcelas = 1;

                    await unitOfWork.ContaReceberRepository.AddAsync(conta);

                    await unitOfWork.CommitAsync();

                    return mapper.Map<ContaReceberResponse>(conta);
                }

                // =========================
                // CONTA PARCELADA
                // =========================
                int totalParcelas = request.QuantidadeParcelas!.Value;

                decimal valorParcela = Math.Round(
                    request.Valor / totalParcelas,
                    2,
                    MidpointRounding.AwayFromZero
                );

                decimal valorRestante = request.Valor;

                // =====================================================
                // 1. CRIA A CONTA PAI (OBRIGATÓRIO PARA SATISFAZER FK)
                // =====================================================
                var contaPai = mapper.Map<ContaReceber>(request);

                contaPai.Status = StatusConta.Aberta;
                contaPai.ValorPago = 0;
                contaPai.DataCadastro = DateTime.Now;
                contaPai.DataEmissao = DateTime.Now;
                contaPai.TipoConta = request.TipoConta;
                contaPai.FormaRecebimento = request.FormaRecebimento;

                contaPai.NumeroParcela = 0;
                contaPai.TotalParcelas = totalParcelas;

                contaPai.Valor = request.Valor;
                contaPai.ContaPaiId = null;

                await unitOfWork.ContaReceberRepository.AddAsync(contaPai);
                await unitOfWork.CommitAsync(); // 🔥 IMPORTANTE: precisa gerar ID

                Guid grupoParcelamentoId = contaPai.Id;

                // =========================
                // 2. CRIA AS PARCELAS
                // =========================
                ContaReceber? primeiraParcela = null;

                for (int i = 1; i <= totalParcelas; i++)
                {
                    var parcela = mapper.Map<ContaReceber>(request);

                    parcela.Status = StatusConta.Aberta;
                    parcela.ValorPago = 0;
                    parcela.DataCadastro = DateTime.Now;
                    parcela.DataEmissao = DateTime.Now;
                    parcela.TipoConta = request.TipoConta;
                    parcela.FormaRecebimento = request.FormaRecebimento;

                    parcela.NumeroParcela = i;
                    parcela.TotalParcelas = totalParcelas;

                    parcela.ContaPaiId = grupoParcelamentoId;

                    parcela.DataVencimento =
                        request.DataVencimento.AddMonths(i - 1);

                    if (i == totalParcelas)
                        parcela.Valor = valorRestante;
                    else
                    {
                        parcela.Valor = valorParcela;
                        valorRestante -= valorParcela;
                    }

                    await unitOfWork.ContaReceberRepository.AddAsync(parcela);

                    if (i == 1)
                        primeiraParcela = parcela;
                }

                await unitOfWork.CommitAsync();

                return mapper.Map<ContaReceberResponse>(primeiraParcela!);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task<ContaReceberResponse> ModificarAsync(
       Guid id,
       ContaReceberUpdateRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var conta = await unitOfWork
                    .ContaReceberRepository
                    .GetByIdAsync(id);

                if (conta == null)
                {
                    throw new BusinessException(
                        "Conta não encontrada."
                    );
                }

                //if (request.Valor <= 0)
                //{
                //    throw new BusinessException(
                //        "O valor deve ser maior que zero."
                //    );
                //}

                //if (conta.ValorPago > 0)
                //{
                //    throw new BusinessException(
                //        "Não é possível alterar uma conta que possui pagamentos."
                //    );
                //}
                ////if (conta.ValorPago > 0 || conta.Parcelas.Any())
                ////{
                ////    throw new BusinessException("Conta não pode ter cliente alterado.");
                ////}
                //if (conta.Parcelado == false && request.Parcelado == true)
                //{
                //    throw new BusinessException(
                //        "Não é permitido alterar conta à vista para parcelada."
                //    );
                //}
                //if (conta.ValorPago > 0)
                //{
                //    throw new BusinessException(
                //        "Conta com baixa financeira não pode ser alterada."
                //    );
                //}
                // ======================================================
                // ATENÇÃO FUTURA - BAIXA FINANCEIRA
                // ======================================================
                //
                // Atualmente este método somente permite alteração
                // de contas sem pagamentos registrados.
                //
                // Quando o módulo de Baixa Financeira estiver concluído:
                //
                // 1) Bloquear alteração de parcelas já pagas;
                // 2) Permitir alteração apenas das parcelas em aberto;
                // 3) Atualizar automaticamente o saldo da conta pai;
                // 4) Atualizar status:
                //      - Aberta
                //      - Parcialmente Paga
                //      - Paga
                //      - Vencida
                //
                // 5) Caso seja alterado o valor total do parcelamento:
                //      - Recalcular parcelas futuras não pagas;
                //
                // 6) Registrar histórico detalhado das parcelas
                //    impactadas pela alteração.
                //
                // NÃO IMPLEMENTAR ANTES DA CONCLUSÃO DO MÓDULO
                // DE BAIXA FINANCEIRA.
                // ======================================================

                // =========================
                // SNAPSHOT ANTES
                // =========================

                var dadosAntes = new
                {
                    conta.Descricao,
                    conta.Valor,
                    conta.DataVencimento,
                    conta.PessoaId,
                    conta.ContratoId,
                    conta.CategoriaFinanceiraId,
                    conta.CentroCustoId,
                    conta.TipoConta,
                    conta.FormaRecebimento
                };

                // =========================
                // ALTERAÇÃO
                // =========================

                conta.Descricao =
                    request.Descricao?.Trim();

                //conta.Valor =
                //    request.Valor;

                //conta.DataVencimento =
                //    request.DataVencimento;

                //conta.PessoaId =
                //    request.PessoaId;

                //conta.ContratoId =
                //    request.ContratoId;

                //conta.CategoriaFinanceiraId =
                //    request.CategoriaFinanceiraId;

                //conta.CentroCustoId =
                //    request.CentroCustoId;

                //conta.TipoConta =
                //    request.TipoConta;

                //conta.FormaRecebimento =
                //    request.FormaRecebimento;

                conta.DataAtualizacao =
                    DateTime.Now;

                await unitOfWork
                    .ContaReceberRepository
                    .UpdateAsync(conta);

                // =========================
                // SNAPSHOT DEPOIS
                // =========================

                var dadosDepois = new
                {
                    conta.Descricao,
                    conta.Valor,
                    conta.DataVencimento,
                    conta.PessoaId,
                    conta.ContratoId,
                    conta.CategoriaFinanceiraId,
                    conta.CentroCustoId,
                    conta.TipoConta,
                    conta.FormaRecebimento
                };

                // =========================
                // HISTÓRICO
                // =========================

                var usuarioId = ObterUsuarioId();

                await historicoGeralService.RegistrarAsync(
                    TipoEntidade.ContaReceber,
                    conta.Id,
                    usuarioId,
                    dadosAntes,
                    dadosDepois,
                    "Conta a receber alterada."
                );

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
                var conta =
                    await unitOfWork
                        .ContaReceberRepository
                        .ObterCompletoPorIdAsync(id);

                if (conta == null)
                    throw new BusinessException("Conta não encontrada.");

                if (conta.Excluido)
                    throw new BusinessException("A conta já foi excluída.");

                // 🔒 Proteção: conta principal já teve movimentação financeira
                var contaPrincipalTemMovimento =
                    conta.ValorRecebido > 0 ||
                    conta.ValorPago > 0 ||
                    conta.Status == StatusConta.Paga ||
                    conta.Status == StatusConta.ParcialmentePaga;

                if (contaPrincipalTemMovimento)
                {
                    throw new BusinessException(
                        "Não é possível excluir uma conta que já possui movimentação financeira."
                    );
                }

                // 🔒 Proteção: parcelas com movimentação
                var possuiParcelasComMovimento =
                    conta.Parcelas != null &&
                    conta.Parcelas.Any(p =>
                        !p.Excluido &&
                        (
                            p.ValorRecebido > 0 ||
                            p.ValorPago > 0 ||
                            p.Status == StatusConta.Paga ||
                            p.Status == StatusConta.ParcialmentePaga
                        )
                    );

                if (possuiParcelasComMovimento)
                {
                    throw new BusinessException(
                        "Não é possível excluir esta conta porque existem parcelas com movimentação financeira. Realize estorno antes da exclusão."
                    );
                }

                // 🧹 Soft delete das parcelas (somente abertas)
                if (conta.Parcelas != null && conta.Parcelas.Any())
                {
                    foreach (var parcela in conta.Parcelas.Where(p => !p.Excluido))
                    {
                        parcela.Excluido = true;
                        parcela.DataExclusao = DateTime.Now;
                        parcela.UsuarioExclusaoId = ObterUsuarioId();

                        await unitOfWork
                            .ContaReceberRepository
                            .UpdateAsync(parcela);
                    }
                }

                // 🧹 Soft delete da conta principal
                conta.Excluido = true;
                conta.DataExclusao = DateTime.Now;
                conta.UsuarioExclusaoId = ObterUsuarioId();

                await unitOfWork
                    .ContaReceberRepository
                    .UpdateAsync(conta);

                await unitOfWork.CommitAsync();

                return mapper.Map<ContaReceberResponse>(conta);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task BaixarAsync(
      Guid id,
      ContaReceberBaixaRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var conta = await unitOfWork
                    .ContaReceberRepository
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

                var baixa = new ContaReceberBaixa
                {
                    Id = Guid.NewGuid(),
                    ContaReceberId = conta.Id,
                    ValorPago = request.ValorPago,
                    DataBaixa = request.DataBaixa,
                    FormaRecebimento = request.FormaRecebimento,
                    Observacao = request.Observacao
                };

                await unitOfWork
                    .ContaReceberBaixaRepository
                    .AddAsync(baixa);

                conta.ValorPago += request.ValorPago;
                conta.ValorRecebido += request.ValorPago;

                if (conta.ValorPago >= conta.Valor)
                {
                    conta.Status = StatusConta.Paga;
                    conta.Quitado = true;
                    conta.DataQuitacao = DateTime.Now;
                    conta.DataBaixa = request.DataBaixa;
                }
                else if (conta.ValorPago > 0)
                {
                    conta.Status = StatusConta.ParcialmentePaga;
                }
                else
                {
                    conta.Status = StatusConta.Aberta;
                }

                conta.DataAtualizacao = DateTime.Now;

                await unitOfWork
                    .ContaReceberRepository
                    .UpdateAsync(conta);

                // Atualiza a conta agrupadora
                if (conta.ContaPaiId.HasValue)
                {
                    var contaPai = await unitOfWork
                        .ContaReceberRepository
                        .ObterCompletoPorIdAsync(
                            conta.ContaPaiId.Value);

                    if (contaPai != null)
                    {
                        var parcelas = contaPai.Parcelas.ToList();

                        var valorPagoPai =
                            parcelas.Sum(x => x.ValorPago);

                        var valorRecebidoPai =
                            parcelas.Sum(x => x.ValorRecebido);

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
                            .ContaReceberRepository
                            .AtualizarContaPaiAsync(
                                contaPai.Id,
                                valorPagoPai,
                                valorRecebidoPai,
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
        public async Task<PageResult<ContaReceberConsultaResponse>> ConsultarPaginacaoAsync(int pageNumber,
int pageSize,
string? searchTerm = null)
        {
            var paged = await unitOfWork.ContaReceberRepository
                .GetPaginacaoAsync(pageNumber, pageSize, searchTerm);
            if (paged == null || !paged.Items.Any())
            {
                return new PageResult<ContaReceberConsultaResponse>
                {
                    Items = new List<ContaReceberConsultaResponse>(),
                    TotalCount = 0,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            return paged;
        }
//        public async Task<PageResult<ContaPagarConsultaResponse>> ConsultarPaginacaoAsync(
//   int pageNumber,
//int pageSize,
//string? searchTerm = null)
//        {
//            var paged = await unitOfWork.ContaPagarRepository
//                .GetPaginacaoAsync(pageNumber, pageSize, searchTerm);

//            if (paged == null || !paged.Items.Any())
//            {
//                return new PageResult<ContaPagarConsultaResponse>
//                {
//                    Items = new List<ContaPagarConsultaResponse>(),
//                    TotalCount = 0,
//                    PageNumber = pageNumber,
//                    PageSize = pageSize
//                };
//            }

//            return paged;
//        }
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

        public Task<PageResult<ContaReceberResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public async Task<ObterContaReceberResponse?> ObterPorIdAsync(Guid id)
        {
            var contaReceber = await unitOfWork
                .ContaReceberRepository
                .ObterCompletoPorIdAsync(id);

            if (contaReceber == null)
                return null;

            return mapper.Map<ObterContaReceberResponse>(contaReceber);
        }
       
    }
}