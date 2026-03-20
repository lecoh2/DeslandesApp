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
        IProcessoRepository ProcessoRepository { get; }
        IGrupoClientesRepository GrupoClientesRepository { get; }
        IGrupoEnvolvidosRepository GrupoEnvolvidosRepository { get; }
        IVaraRepository VaraRepository { get; }
        ITarefaRepository TarefaRepository { get; }
        IListaTarefaRepository ListaTarefaRepository { get; }
        IGrupoTarefaEnvolvidoRepository GrupoTarefaEnvolvidoRepository { get; }
        IAtendimentoRepository AtendimentoRepository { get; }
        ICasoRepository CasoRepository { get; }
        IGrupoCasoClienteRepository GrupoCasoClienteRepository { get; }
        IGrupoCasoEnvolvidosRepository GrupoCasoEnvolvidosRepository { get; }
        #endregion
    }
}
