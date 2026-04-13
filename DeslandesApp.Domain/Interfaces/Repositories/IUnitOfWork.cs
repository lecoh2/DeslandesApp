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
        IPessoaHistoricoRepository PessoaHistoricoRepository { get; }
        IProcessoHistoricoRepository ProcessoHistoricoRepository { get; }
        IProcessoRepository ProcessoRepository { get; }
        IGrupoClientesRepository GrupoClientesRepository { get; }
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
        ITarefaEtiquetaRepository TarefaEtiquetaRepository { get; }
        IGrupoEventoResponsavelRepository GrupoEventoResponsavelRepository { get; }
        IEventoRepository EventoRepository { get; }
        IProcessoEtiquetaRepository ProcessoEtiquetaRepository { get; } 
        IGrupoClientesProcessosRepository GrupoClientesProcessosRepository { get; }
        IGrupoEnvolvidosProcessoRepository GrupoEnvolvidosProcessosRepository { get; }
        IGrupoEtiquetasProcessosRepository GrupoEtiquetasProcessosRepository { get; }
        IGrupoEtiquetasAtendimentoRepository GrupoEtiquetasAtendimentoRepository { get;  }
        IGrupoEtiquetaCasoRepository GrupoEtiquetaCasoRepository { get; }
        IAtendimentoHistoricoRepository AtendimentoHistoricoRepository { get; }
        ICasoHistoricoRepository CasoHistoricoRepository { get; }
        IEventoHistoricoRepository EventoHistoricoRepository { get;  }
        IGrupoPessoasEtiquetasRepository GrupoPessoasEtiquetasRepository { get; }
        IContaBancariaRepository ContaBancariaRepository { get; }
        IAcaoRepository AcaoRepository { get; }
        #endregion
    }
}
