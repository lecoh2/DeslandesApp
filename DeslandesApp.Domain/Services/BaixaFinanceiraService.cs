using AutoMapper;
using DeslandesApp.Domain.Exceptions;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.BaixaFinanceira;
using DeslandesApp.Domain.Models.Dtos.Responses.BaixaFinanceira;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.DashboardFinanceiro;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using Microsoft.AspNetCore.Http;

namespace DeslandesApp.Domain.Services
{
    public class BaixaFinanceiraService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
    ) : BaseService(httpContextAccessor), IBaixaFinanceiraService
    {
        //public async Task<BaixaFinanceiraResponse> AdicionarAsync(
        //    BaixaFinanceiraRequest request)
        //{
        //    await unitOfWork.BeginTransactionAsync();

        //    try
        //    {
        //        if (request.ContaReceberId == null)
        //        {
        //            throw new BusinessException(
        //                "Conta a receber não informada."
        //            );
        //        }

        //        if (request.ValorPago <= 0)
        //        {
        //            throw new BusinessException(
        //                "O valor da baixa deve ser maior que zero."
        //            );
        //        }

        //        var conta = await unitOfWork
        //            .ContaReceberRepository
        //            .GetByIdAsync(request.ContaReceberId);

        //        if (conta == null)
        //        {
        //            throw new BusinessException(
        //                "Conta não encontrada."
        //            );
        //        }

        //        if (conta.Excluido)
        //        {
        //            throw new BusinessException(
        //                "Não é possível baixar uma conta excluída."
        //            );
        //        }

        //        if (conta.Quitado)
        //        {
        //            throw new BusinessException(
        //                "Esta conta já está quitada."
        //            );
        //        }

        //        var saldoAtual =
        //            conta.Valor - conta.ValorRecebido;

        //        if (request.ValorPago > saldoAtual)
        //        {
        //            throw new BusinessException(
        //                $"O valor informado excede o saldo da conta. Saldo atual: {saldoAtual:C2}"
        //            );
        //        }

        //        var baixa = mapper.Map<BaixaFinanceira>(request);

        //        baixa.DataCadastro = DateTime.Now;
        //        baixa.UsuarioCadastroId = ObterUsuarioId();

        //        await unitOfWork
        //            .BaixaFinanceiraRepository
        //            .AddAsync(baixa);

        //        conta.ValorRecebido += request.ValorPago;
        //        conta.DataQuitacao = request.DataQuitacao;

        //        if (conta.ValorRecebido == 0)
        //        {
        //            conta.Status = StatusConta.Aberta;
        //            conta.Quitado = false;
        //            conta.DataQuitacao = null;
        //        }
        //        else if (conta.ValorRecebido < conta.Valor)
        //        {
        //            conta.Status = StatusConta.ParcialmentePaga;
        //            conta.Quitado = false;
        //            conta.DataQuitacao = null;
        //        }
        //        else
        //        {
        //            conta.Status = StatusConta.Paga;
        //            conta.Quitado = true;
        //            conta.DataQuitacao = DateTime.Now;
        //        }

        //        conta.DataAtualizacao = DateTime.Now;
        //        conta.UsuarioAtualizacaoId = ObterUsuarioId();

        //        await unitOfWork
        //            .ContaReceberRepository
        //            .UpdateAsync(conta);

        //        await unitOfWork.CommitAsync();

        //        return mapper.Map<BaixaFinanceiraResponse>(baixa);
        //    }
        //    catch
        //    {
        //        await unitOfWork.RollbackAsync();
        //        throw;
        //    }
        //}
        public async Task<BaixaFinanceiraResponse> AdicionarAsync(
    BaixaFinanceiraRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                if (request.ContaReceberId.HasValue &&
    request.ContaPagarId.HasValue)
                {
                    throw new BusinessException(
                        "Informe apenas uma conta por baixa."
                    );
                }
                if (!request.ContaReceberId.HasValue &&
                    !request.ContaPagarId.HasValue)
                {
                    throw new BusinessException(
                        "Informe uma conta a receber ou uma conta a pagar."
                    );
                }

                if (request.ValorPago <= 0)
                {
                    throw new BusinessException(
                        "O valor da baixa deve ser maior que zero."
                    );
                }

                var baixa = mapper.Map<BaixaFinanceira>(request);

                baixa.DataCadastro = DateTime.Now;
                baixa.UsuarioCadastroId = ObterUsuarioId();

                // ==========================================
                // CONTA A RECEBER
                // ==========================================
                if (request.ContaReceberId.HasValue)
                {
                    var conta = await unitOfWork
                        .ContaReceberRepository
                        .GetByIdAsync(request.ContaReceberId.Value);

                    if (conta == null)
                    {
                        throw new BusinessException(
                            "Conta a receber não encontrada."
                        );
                    }

                    if (conta.Excluido)
                    {
                        throw new BusinessException(
                            "Não é possível baixar uma conta excluída."
                        );
                    }

                    if (conta.Quitado)
                    {
                        throw new BusinessException(
                            "Esta conta já está quitada."
                        );
                    }

                    var saldoAtual =
                        conta.Valor - conta.ValorRecebido;

                    if (request.ValorPago > saldoAtual)
                    {
                        throw new BusinessException(
                            $"O valor informado excede o saldo da conta. Saldo atual: {saldoAtual:C2}"
                        );
                    }

                    conta.ValorRecebido += request.ValorPago;

                    if (conta.ValorRecebido == 0)
                    {
                        conta.Status = StatusConta.Aberta;
                        conta.Quitado = false;
                        conta.DataQuitacao = null;
                    }
                    else if (conta.ValorRecebido < conta.Valor)
                    {
                        conta.Status = StatusConta.ParcialmentePaga;
                        conta.Quitado = false;
                        conta.DataQuitacao = null;
                    }
                    else
                    {
                        conta.Status = StatusConta.Paga;
                        conta.Quitado = true;
                        conta.DataQuitacao = DateTime.Now;
                    }

                    conta.DataAtualizacao = DateTime.Now;
                    conta.UsuarioAtualizacaoId = ObterUsuarioId();

                    await unitOfWork
                        .ContaReceberRepository
                        .UpdateAsync(conta);
                }

                // ==========================================
                // CONTA A PAGAR
                // ==========================================
                if (request.ContaPagarId.HasValue)
                {
                    var conta = await unitOfWork
                        .ContaPagarRepository
                        .GetByIdAsync(request.ContaPagarId.Value);

                    if (conta == null)
                    {
                        throw new BusinessException(
                            "Conta a pagar não encontrada."
                        );
                    }

                    if (conta.Excluido)
                    {
                        throw new BusinessException(
                            "Não é possível baixar uma conta excluída."
                        );
                    }

                    if (conta.Quitado)
                    {
                        throw new BusinessException(
                            "Esta conta já está quitada."
                        );
                    }

                    var saldoAtual =
                        conta.Valor - conta.ValorPago;

                    if (request.ValorPago > saldoAtual)
                    {
                        throw new BusinessException(
                            $"O valor informado excede o saldo da conta. Saldo atual: {saldoAtual:C2}"
                        );
                    }

                    conta.ValorPago += request.ValorPago;

                    if (conta.ValorPago == 0)
                    {
                        conta.Status = StatusConta.Aberta;
                        conta.Quitado = false;
                        conta.DataQuitacao = null;
                    }
                    else if (conta.ValorPago < conta.Valor)
                    {
                        conta.Status = StatusConta.ParcialmentePaga;
                        conta.Quitado = false;
                        conta.DataQuitacao = null;
                    }
                    else
                    {
                        conta.Status = StatusConta.Paga;
                        conta.Quitado = true;
                        conta.DataQuitacao = DateTime.Now;
                    }

                    conta.DataAtualizacao = DateTime.Now;
                    conta.UsuarioAtualizacaoId = ObterUsuarioId();

                    await unitOfWork
                        .ContaPagarRepository
                        .UpdateAsync(conta);
                }

                await unitOfWork
                    .BaixaFinanceiraRepository
                    .AddAsync(baixa);

                await unitOfWork.CommitAsync();

                return mapper.Map<BaixaFinanceiraResponse>(baixa);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task<List<MovimentacaoFinanceiraResponse>>
        ObterUltimasMovimentacoesAsync(
            int quantidade = 10)
        {
            return await unitOfWork
                .BaixaFinanceiraRepository
                .ObterUltimasMovimentacoesAsync(
                    quantidade);
        }
        public async Task<BaixaFinanceiraResponse> ModificarAsync(
            Guid id,
            BaixaFinanceiraUpdateRequest request)
        {
            throw new BusinessException(
                "Alteração de baixa financeira não é permitida. Exclua e realize uma nova baixa."
            );
        }

        //public async Task<BaixaFinanceiraResponse> ExcluirAsync(Guid id)
        //{
        //    await unitOfWork.BeginTransactionAsync();

        //    try
        //    {
        //        var baixa = await unitOfWork
        //            .BaixaFinanceiraRepository
        //            .GetByIdAsync(id);

        //        if (baixa == null)
        //        {
        //            throw new BusinessException(
        //                "Baixa financeira não encontrada."
        //            );
        //        }

        //        if (baixa.ContaReceberId.HasValue)
        //        {
        //            var conta = await unitOfWork
        //                .ContaReceberRepository
        //                .GetByIdAsync(baixa.ContaReceberId.Value);

        //            if (conta != null)
        //            {
        //                conta.ValorRecebido -= baixa.ValorPago;

        //                if (conta.ValorRecebido < 0)
        //                {
        //                    conta.ValorRecebido = 0;
        //                }

        //                if (conta.ValorRecebido == 0)
        //                {
        //                    conta.Status = StatusConta.Aberta;
        //                    conta.Quitado = false;
        //                    conta.DataQuitacao = null;
        //                }
        //                else
        //                {
        //                    conta.Status = StatusConta.ParcialmentePaga;
        //                    conta.Quitado = false;
        //                    conta.DataQuitacao = null;
        //                }

        //                conta.DataAtualizacao = DateTime.Now;
        //                conta.UsuarioAtualizacaoId = ObterUsuarioId();

        //                await unitOfWork
        //                    .ContaReceberRepository
        //                    .UpdateAsync(conta);
        //            }
        //        }

        //        await unitOfWork
        //            .BaixaFinanceiraRepository
        //            .DeleteAsync(baixa);

        //        await unitOfWork.CommitAsync();

        //        return mapper.Map<BaixaFinanceiraResponse>(baixa);
        //    }
        //    catch
        //    {
        //        await unitOfWork.RollbackAsync();
        //        throw;
        //    }
        //}
        public async Task<BaixaFinanceiraResponse> ExcluirAsync(Guid id)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var baixa = await unitOfWork
                    .BaixaFinanceiraRepository
                    .GetByIdAsync(id);

                if (baixa == null)
                {
                    throw new BusinessException(
                        "Baixa financeira não encontrada."
                    );
                }

                // ==========================================
                // CONTA A RECEBER
                // ==========================================
                if (baixa.ContaReceberId.HasValue)
                {
                    var conta = await unitOfWork
                        .ContaReceberRepository
                        .GetByIdAsync(baixa.ContaReceberId.Value);

                    if (conta != null)
                    {
                        conta.ValorRecebido -= baixa.ValorPago;

                        if (conta.ValorRecebido < 0)
                        {
                            conta.ValorRecebido = 0;
                        }

                        if (conta.ValorRecebido == 0)
                        {
                            conta.Status = StatusConta.Aberta;
                            conta.Quitado = false;
                            conta.DataQuitacao = null;
                        }
                        else
                        {
                            conta.Status = StatusConta.ParcialmentePaga;
                            conta.Quitado = false;
                            conta.DataQuitacao = null;
                        }

                        conta.DataAtualizacao = DateTime.Now;
                        conta.UsuarioAtualizacaoId = ObterUsuarioId();

                        await unitOfWork
                            .ContaReceberRepository
                            .UpdateAsync(conta);
                    }
                }

                // ==========================================
                // CONTA A PAGAR
                // ==========================================
                if (baixa.ContaPagarId.HasValue)
                {
                    var conta = await unitOfWork
                        .ContaPagarRepository
                        .GetByIdAsync(baixa.ContaPagarId.Value);

                    if (conta != null)
                    {
                        conta.ValorPago -= baixa.ValorPago;

                        if (conta.ValorPago < 0)
                        {
                            conta.ValorPago = 0;
                        }

                        if (conta.ValorPago == 0)
                        {
                            conta.Status = StatusConta.Aberta;
                            conta.Quitado = false;
                            conta.DataQuitacao = null;
                        }
                        else
                        {
                            conta.Status = StatusConta.ParcialmentePaga;
                            conta.Quitado = false;
                            conta.DataQuitacao = null;
                        }

                        conta.DataAtualizacao = DateTime.Now;
                        conta.UsuarioAtualizacaoId = ObterUsuarioId();

                        await unitOfWork
                            .ContaPagarRepository
                            .UpdateAsync(conta);
                    }
                }

                await unitOfWork
                    .BaixaFinanceiraRepository
                    .DeleteAsync(baixa);

                await unitOfWork.CommitAsync();

                return mapper.Map<BaixaFinanceiraResponse>(baixa);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<List<BaixaFinanceiraResponse>> ConsultarAsync()
        {
            var result = await unitOfWork
                .BaixaFinanceiraRepository
                .GetAllAsync();

            return mapper.Map<List<BaixaFinanceiraResponse>>(result);
        }

        public async Task<BaixaFinanceiraResponse?> ObterPorIdAsync(Guid id)
        {
            var baixa = await unitOfWork
                .BaixaFinanceiraRepository
                .GetByIdAsync(id);

            return mapper.Map<BaixaFinanceiraResponse>(baixa);
        }

 

        public Task<PageResult<BaixaFinanceiraResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<List<BaixaFinanceiraResponse>> ConsultarPorContaReceberAsync(Guid contaReceberId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BaixaFinanceiraResponse>> ConsultarPorContaPagarAsync(Guid contaPagarId)
        {
            throw new NotImplementedException();
        }
    }
}