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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class ContasPagarReceberService(
IUnitOfWork unitOfWork,
IMapper mapper,
IHttpContextAccessor httpContextAccessor,
IHistoricoGeralService historicoGeralService
) : BaseService(httpContextAccessor), IContasPagarReceberService
    {
        public Task<CriarContaFinanceiraResponse> AdicionarAsync(CriarContaFinanceiraRequest request)
        {
            throw new NotImplementedException();
        }

        public Task BaixarPagamentoAsync(Guid id, decimal valorPago)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<CriarContaFinanceiraResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CriarAsync(CriarContaFinanceiraRequest request)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<CriarContaFinanceiraResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CriarContaFinanceiraResponse> ModificarAsync(Guid id, CriarContaFinanceiraUpdateRequest request)
        {
            throw new NotImplementedException();
        }


        //public async Task<Guid> CriarAsync(CriarContaFinanceiraRequest request)
        //{
        //    var conta = new ContaFinanceira
        //    {
        //        Id = Guid.NewGuid(),
        //        Tipo = request.Tipo,
        //        Valor = request.Valor,
        //        ValorPago = 0,
        //        DataEmissao = DateTime.Now,
        //        DataVencimento = request.DataVencimento,
        //        Status = StatusContaFinanceira.Aberta,
        //        Descricao = request.Descricao,
        //        ProcessoId = request.ProcessoId,
        //        CasoId = request.CasoId,
        //        AtendimentoId = request.AtendimentoId,
        //        ClienteId = request.ClienteId
        //    };

        //    await _unitOfWork.ContaFinanceiraRepository.AddAsync(conta);
        //    await _unitOfWork.CommitAsync();

        //    return conta.Id;
        //}
        //public async Task BaixarPagamentoAsync(Guid id, decimal valorPago)
        //{
        //    var conta = await unitOfWork.ContaFinanceiraRepository.GetByIdAsync(id)
        //        ?? throw new Exception("Conta não encontrada");

        //    conta.ValorPago += valorPago;

        //    if (conta.ValorPago >= conta.Valor)
        //    {
        //        conta.Status = StatusContaFinanceira.Paga;
        //        conta.DataPagamento = DateTime.Now;
        //    }
        //    else
        //    {
        //        conta.Status = StatusContaFinanceira.ParcialmentePaga;
        //    }

        //    await unitOfWork.CommitAsync();
        //}
    }
}

