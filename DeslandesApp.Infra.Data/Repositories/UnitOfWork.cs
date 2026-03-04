using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class UnitOfWork(DataContext dataContext) : IUnitOfWork
    {
        private IDbContextTransaction? transaction;
        public void BeginTransaction()
        {
            if (transaction != null)
                return;

            transaction = dataContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null)
                transaction.Rollback();
        }
        public void Rollback()
        {
            if(transaction !=null)
                transaction.Rollback();
        }
        public void Dispose()
        {
            if (transaction != null)
                transaction.Dispose();
            dataContext.Dispose();
        }

      
    }
}
