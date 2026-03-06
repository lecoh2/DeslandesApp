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
        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion

        #region Acessos aos repositórios
        #endregion
    }
}
