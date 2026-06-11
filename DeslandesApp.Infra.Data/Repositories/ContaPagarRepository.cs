using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Dtos.Responses.Conta.DeslandesApp.Domain.Models.Dtos.Responses.Conta;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Infra.Data.Contexts;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class ContaPagarRepository(DataContext dataContext)
          : BaseRepository<ContaPagar, Guid>(dataContext), IContaPagarRepository
    {
        public async Task<PageResult<ContaPagarConsultaResponse>> GetPaginacaoAsync(
    int pageNumber,
    int pageSize,
    string? searchTerm = null)
        {
            var query = dataContext.ContaPagar
                .AsNoTracking()
                .Where(x =>
                    !x.Excluido &&
                    (
                        (!x.Parcelado && x.NumeroParcela == 1)
                        || (x.Parcelado && x.NumeroParcela == 0)
                    ));

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(x =>
                    EF.Functions.Like(x.Descricao, $"%{searchTerm}%") ||
                    EF.Functions.Like(x.Pessoa.Nome, $"%{searchTerm}%"));
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.DataCadastro)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new ContaPagarConsultaResponse
                {
                    Id = x.Id,
                    Fornecedor = x.Pessoa.Nome,
                    Descricao = x.Descricao,
                    NumeroContrato = x.Contrato != null ? x.Contrato.Numero : string.Empty,
                    ValorTotal = x.Valor,
                    Parcelado = x.Parcelado,
                    TotalParcelas = x.TotalParcelas,
                    Status = x.Status,
                    StatusDescricao =
                        x.Status == StatusConta.Aberta ? "Pendente" :
                        x.Status == StatusConta.Paga ? "Paga" :
                        x.Status == StatusConta.Cancelada ? "Cancelada" :
                        x.Status == StatusConta.ParcialmentePaga ? "Parcialmente Paga" :
                        "-"
                })
                .ToListAsync();

            return new PageResult<ContaPagarConsultaResponse>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public async Task<List<ContaPagar>> ConsultarComRelacionamentosAsync()
        {
            return await dataContext.ContaPagar
                .AsNoTracking()
                .Include(x => x.Pessoa)
                .Include(x => x.Contrato)
                .Include(x => x.CategoriaFinanceira)
                .ToListAsync();
        }

        public async Task<ContaPagar?> ObterCompletoPorIdAsync(Guid id)
        {
            return await dataContext.ContaPagar
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Pessoa)
                .Include(x => x.Contrato)
                .Include(x => x.CategoriaFinanceira)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ContaPagar>> ConsultarUltimasAsync(int quantidade)
        {
            return await dataContext.ContaPagar
                .OrderByDescending(x => x.DataVencimento)
                .Take(quantidade)
                .ToListAsync();
        }

        public async Task<int> ContarTotalAsync()
        {
            return await dataContext.ContaPagar.CountAsync();
        }

        public async Task<int> ContarAnoAtualAsync()
        {
            var inicioAno = new DateTime(DateTime.Now.Year, 1, 1);
            var fimAno = new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59);

            return await dataContext.ContaPagar
                .Where(x => x.DataVencimento >= inicioAno && x.DataVencimento <= fimAno)
                .CountAsync();
        }

        public async Task<bool> ExisteDuplicidadeAsync(
         Guid? contratoId,
         string descricao,
         decimal valor,
         DateTime dataVencimento)
        {
            return await dataContext.ContaPagar
                .AnyAsync(x =>
                    x.ContratoId == contratoId &&
                    x.Descricao == descricao &&
                    Math.Abs(x.Valor - valor) < 0.01m &&
                    x.DataVencimento.Date == dataVencimento.Date &&
                    !x.Excluido);
        }
    }
}