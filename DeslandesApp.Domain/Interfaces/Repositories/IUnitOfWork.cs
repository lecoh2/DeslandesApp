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
        #endregion
    }
}
