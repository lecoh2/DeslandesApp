using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.DashboardFinanceiro
{
    public class DashboardFinanceiroResponse
    {
        public decimal TotalReceberMes { get; set; }

        public decimal TotalRecebidoMes { get; set; }

        public decimal TotalPagarMes { get; set; }

        public decimal TotalPagoMes { get; set; }

        public decimal SaldoMes { get; set; }

        public decimal Inadimplencia { get; set; }

        public List<GraficoReceitaDespesaResponse> ReceitaDespesa { get; set; }
            = new();

        public List<GraficoCategoriaResponse> Categorias { get; set; }
            = new();

        public List<MovimentacaoFinanceiraResponse> UltimasMovimentacoes { get; set; }
            = new();
        public decimal MetaMensal { get; set; }

        public decimal PercentualMeta { get; set; }


        public bool MetaAutomatica { get; set; }
    

        public decimal MetaAnual { get; set; }

        public List<FluxoPrevistoRealizadoResponse>
         FluxoPrevistoRealizado
        { get; set; }
         = [];
        public List<FluxoCaixaFuturoResponse>
    FluxoCaixaFuturo
        { get; set; }
    = [];
        public List<FluxoCaixaProjetadoResponse>
   FluxoCaixaProjetado
        { get; set; }
   = [];


    }
}
