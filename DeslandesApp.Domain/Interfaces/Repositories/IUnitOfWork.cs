using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        #region Operações de transação
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();

        #endregion

        #region Acessos aos repositórios
        IWebJurPublicacaoRepository WebJurPublicacaoRepository { get; }
        IWebJurSincronizacaoLogRepository WebJurSincronizacaoLogRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IPessoaRepository PessoaRepository { get; }
        INivelRepository NivelRepository { get; }
        ISetorRepository SetorRepository { get; }
        IGrupoSetoresRepository GrupoSetoresRepository { get; } 
        IGrupoNiveisRepository GrupoNiveisRepository { get; }
        IFailedLoginAttemptRepository FailedLoginAttemptRepository { get; }
        ILoginHistoryRepository LoginHistoryRepository { get; }
        IEnderecoRepository EnderecoRepository { get; }
        IInformacoesComplementaresRepository InformacoesComplementaresRepository { get;  }
        IFotoRepository FotoRepository { get; }
        IProcessoRepository ProcessoRepository { get; }
        IGrupoClientesRepository GrupoClientesRepository { get; }
        IGrupoClientesProcessosRepository GrupoClientesProcessosRepository { get; }
        IContratoProcessoRepository ContratoProcessoRepository { get; }
        IGrupoEnvolvidosRepository GrupoEnvolvidosRepository { get; }
        IVaraRepository VaraRepository { get; }
        ITarefaRepository TarefaRepository { get; }
        IListaTarefaRepository ListaTarefaRepository { get; }
        IGrupoTarefaResponsaveisRepository GrupoTarefaResponsaveisRepository { get; }
        IAtendimentoRepository AtendimentoRepository { get; }
        ICasoRepository CasoRepository { get; }
        IGrupoCasoClienteRepository GrupoCasoClienteRepository { get; }
        IGrupoCasoEnvolvidosRepository GrupoCasoEnvolvidosRepository { get; }
        IQualificacaoRepository QualificacaoRepository { get; }
        IGrupoAtendimentoClienteRepository GrupoAtendimentoClienteRepository { get; }       
        IEtiquetaRepository EtiquetaRepository { get; }
        IGrupoTarefasEtiquetasRepository GrupoTarefasEtiquetasRepository { get; }
        IGrupoEventoResponsavelRepository GrupoEventoResponsavelRepository { get; }
        IEventoRepository EventoRepository { get; }
            IAndamentoProcessoRepository AndamentoProcessoRepository { get; }
        IGrupoEnvolvidosProcessoRepository GrupoEnvolvidosProcessosRepository { get; }
        IGrupoEtiquetasProcessosRepository GrupoEtiquetasProcessosRepository { get; }
        IGrupoEtiquetasAtendimentoRepository GrupoEtiquetasAtendimentoRepository { get;  }
        IGrupoEtiquetaCasoRepository GrupoEtiquetaCasoRepository { get; }
        IAtendimentoHistoricoRepository AtendimentoHistoricoRepository { get; }
       
        IGrupoPessoasEtiquetasRepository GrupoPessoasEtiquetasRepository { get; }
        IContaBancariaRepository ContaBancariaRepository { get; }
        IAcaoRepository AcaoRepository { get; }
        IGrupoEventoEtiquetasRepository GrupoEventoEtiquetasRepository { get; }
        IComentarioRepository ComentarioRepository { get; }
        IHistoricoGeralRepository HistoricoGeralRepository { get; }
        INotificacaoRepository NotificacaoRepository { get; }
        IContaReceberRepository ContaReceberRepository { get; }

        IContaPagarRepository ContaPagarRepository { get; }
        IBaixaFinanceiraRepository BaixaFinanceiraRepository { get; }
        ICentroCustoRepository CentroCustoRepository { get; }
        IContratoRepository ContratoRepository { get; }
        ICategoriaFinanceiraRepository CategoriaFinanceiraRepository { get; }

           IContaReceberBaixaRepository ContaReceberBaixaRepository { get; }
        IConfiguracaoFinanceiraRepository ConfiguracaoFinanceiraRepository { get; }
        IWebJurComentarioRepository WebJurComentarioRepository { get; }

        IWebJurMovimentacaoRepository WebJurMovimentacaoRepository { get; }

        IWebJurArquivoRepository WebJurArquivoRepository { get; }

        IWebJurVisualizacaoRepository WebJurVisualizacaoRepository { get; }

        IWebJurSincronizacaoRepository WebJurSincronizacaoRepository { get; }

        #endregion
    }
}
