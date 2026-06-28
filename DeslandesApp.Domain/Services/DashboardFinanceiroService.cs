using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Responses.DashboardFinanceiro;

namespace DeslandesApp.Domain.Services
{
    public class DashboardFinanceiroService(
         IUnitOfWork unitOfWork,
         IMapper mapper)
         : IDashboardFinanceiroService
    {
        public async Task<DashboardFinanceiroResponse> ObterDashboardAsync(int? ano = null, int? mes = null)
        {
            ano ??= DateTime.Now.Year;
            mes ??= DateTime.Now.Month;

            var totalReceber =
                await unitOfWork.ContaReceberRepository.ObterTotalReceberMesAsync(ano.Value, mes.Value);

            var totalRecebido =
                await unitOfWork.ContaReceberRepository.ObterTotalRecebidoMesAsync(ano.Value, mes.Value);

            var totalPagar =
                await unitOfWork.ContaPagarRepository.ObterTotalPagarMesAsync(ano.Value, mes.Value);

            var totalPago =
                await unitOfWork.ContaPagarRepository.ObterTotalPagoMesAsync(ano.Value, mes.Value);

            var inadimplencia =
                await unitOfWork.ContaReceberRepository.ObterInadimplenciaAsync();

            var receitas =
                await unitOfWork.ContaReceberRepository.ObterReceitasPorMesAsync(ano.Value);

            var despesas =
                await unitOfWork.ContaPagarRepository.ObterDespesasPorMesAsync(ano.Value);

            var configuracao =
                await unitOfWork.ConfiguracaoFinanceiraRepository.ObterAsync();

            // =========================
            // 🔥 META HÍBRIDA
            // =========================

            decimal metaMensal;
            bool metaAutomatica;

            if (configuracao != null && configuracao.MetaMensal > 0)
            {
                // ✔️ META MANUAL
                metaMensal = configuracao.MetaMensal;
                metaAutomatica = false;
            }
            else
            {
                // ✔️ META AUTOMÁTICA (fallback)
                metaMensal =
                    await unitOfWork
                        .ContaReceberRepository
                        .ObterMetaMensalInteligenteAsync();

                metaAutomatica = true;
            }

            var percentualMeta =
                metaMensal > 0
                    ? Math.Round((totalRecebido / metaMensal) * 100, 2)
                    : 0;

            var receitaDespesa =
                Enumerable.Range(1, 12)
                    .Select(m => new GraficoReceitaDespesaResponse
                    {
                        Mes = new DateTime(ano.Value, m, 1).ToString("MMM"),

                        Receitas = receitas.TryGetValue(m, out var r) ? r : 0,
                        Despesas = despesas.TryGetValue(m, out var d) ? d : 0
                    })
                    .ToList();

            var categorias =
                await unitOfWork.ContaPagarRepository.ObterGraficoCategoriaDespesaAsync(ano.Value);
            var previsto =
    await unitOfWork
        .ContaReceberRepository
        .ObterPrevistoPorMesAsync(
            ano.Value);

            var realizado =
                await unitOfWork
                    .ContaReceberRepository
                    .ObterRealizadoPorMesAsync(
                        ano.Value);
            var fluxoPrevistoRealizado =
    Enumerable.Range(1, 12)
    .Select(m => new FluxoPrevistoRealizadoResponse
    {
        Mes = new DateTime(
            ano.Value,
            m,
            1)
            .ToString("MMM"),

        Previsto =
            previsto.TryGetValue(
                m,
                out var prev)
                    ? prev
                    : 0,

        Realizado =
            realizado.TryGetValue(
                m,
                out var real)
                    ? real
                    : 0
    }).ToList();
            //var fluxoProjetado =
    //await ObterFluxoCaixaProjetadoAsync();
    var fluxoProjetado =
    await ObterFluxoCaixaProjetadoInteligenteAsync();
            var movimentacoes =
                await unitOfWork.BaixaFinanceiraRepository.ObterUltimasMovimentacoesAsync(10);
            var hoje = DateTime.Today;

            var entrada30 =
                await unitOfWork
                    .ContaReceberRepository
                    .ObterEntradasAteDataAsync(
                        hoje.AddDays(30));

            var saida30 =
                await unitOfWork
                    .ContaPagarRepository
                    .ObterSaidasAteDataAsync(
                        hoje.AddDays(30));

            var entrada60 =
                await unitOfWork
                    .ContaReceberRepository
                    .ObterEntradasAteDataAsync(
                        hoje.AddDays(60));

            var saida60 =
                await unitOfWork
                    .ContaPagarRepository
                    .ObterSaidasAteDataAsync(
                        hoje.AddDays(60));

            var entrada90 =
                await unitOfWork
                    .ContaReceberRepository
                    .ObterEntradasAteDataAsync(
                        hoje.AddDays(90));

            var saida90 =
                await unitOfWork
                    .ContaPagarRepository
                    .ObterSaidasAteDataAsync(
                        hoje.AddDays(90));
            var fluxoCaixaFuturo =
    new List<FluxoCaixaFuturoResponse>
    {
        new()
        {
            Periodo = "30 Dias",
            Entradas = entrada30,
            Saidas = saida30,
            Saldo = entrada30 - saida30
        },

        new()
        {
            Periodo = "60 Dias",
            Entradas = entrada60,
            Saidas = saida60,
            Saldo = entrada60 - saida60
        },

        new()
        {
            Periodo = "90 Dias",
            Entradas = entrada90,
            Saidas = saida90,
            Saldo = entrada90 - saida90
        }
    };
     
            return new DashboardFinanceiroResponse
            {
                TotalReceberMes = totalReceber,
                TotalRecebidoMes = totalRecebido,
                TotalPagarMes = totalPagar,
                TotalPagoMes = totalPago,

                SaldoMes = totalRecebido - totalPago,
                Inadimplencia = inadimplencia,

                MetaMensal = metaMensal,
                PercentualMeta = percentualMeta,
                MetaAutomatica = metaAutomatica,
                MetaAnual = configuracao?.MetaAnual ?? 0,
                ReceitaDespesa = receitaDespesa,
                Categorias = categorias,
                UltimasMovimentacoes = movimentacoes,
                FluxoPrevistoRealizado =
    fluxoPrevistoRealizado,
                FluxoCaixaFuturo =
    fluxoCaixaFuturo,
                //        FluxoCaixaProjetado =
                //fluxoProjetado
                FluxoCaixaProjetado = fluxoProjetado
            };
        }

        public Task<DashboardFinanceiroResponse> ObterDashboardAsync()
        {
            return ObterDashboardAsync(DateTime.Now.Year, DateTime.Now.Month);
        }
        //    private async Task<List<FluxoCaixaProjetadoResponse>>
        //ObterFluxoCaixaProjetadoAsync()
        //    {
        //        var fluxo =
        //            new List<FluxoCaixaProjetadoResponse>();

        //        decimal saldoAcumulado = 0;

        //        for (int i = 0; i < 90; i++)
        //        {
        //            var data =
        //                DateTime.Today.AddDays(i);

        //            var receber =
        //                await unitOfWork
        //                    .ContaReceberRepository
        //                    .ObterEntradasDoDiaAsync(data);

        //            var pagar =
        //                await unitOfWork
        //                    .ContaPagarRepository
        //                    .ObterSaidasDoDiaAsync(data);

        //            saldoAcumulado +=
        //                receber - pagar;

        //            fluxo.Add(
        //                new FluxoCaixaProjetadoResponse
        //                {
        //                    Data = data,
        //                    PrevistoReceber = receber,
        //                    PrevistoPagar = pagar,
        //                    SaldoProjetado = saldoAcumulado
        //                });
        //        }

        //        return fluxo;
        //    }
        private async Task<List<FluxoCaixaProjetadoResponse>>
        ObterFluxoCaixaProjetadoInteligenteAsync()
        {
            var hoje = DateTime.Today;

            var fluxo =
                new List<FluxoCaixaProjetadoResponse>();

            decimal saldo = 0;

            for (int i = 0; i < 90; i++)
            {
                var data = hoje.AddDays(i);

                var baseReceber =
                    await unitOfWork
                        .ContaReceberRepository
                        .ObterEntradasDoDiaAsync(data);

                var basePagar =
                    await unitOfWork
                        .ContaPagarRepository
                        .ObterSaidasDoDiaAsync(data);

                // =========================
                // 🔥 INTELIGÊNCIA FINANCEIRA
                // =========================

                var atrasoReceber =
                    baseReceber * 0.30m; // 30% atraso médio

                var recebimentoReal =
                    baseReceber - atrasoReceber;

                var deslocadoPara7Dias =
                    atrasoReceber * 0.70m;

                var deslocadoPara15Dias =
                    atrasoReceber * 0.30m;

                var pagarAtrasado =
                    basePagar * 0.20m;

                var pagarNoPrazo =
                    basePagar - pagarAtrasado;

                var saldoDia =
                    recebimentoReal - pagarNoPrazo;

                saldo += saldoDia;

                fluxo.Add(new FluxoCaixaProjetadoResponse
                {
                    Data = data,

                    PrevistoReceber = recebimentoReal,

                    PrevistoPagar = basePagar,

                    SaldoDia = saldoDia,

                    SaldoAcumulado = saldo
                });
            }

            return fluxo;
        }
    }
}