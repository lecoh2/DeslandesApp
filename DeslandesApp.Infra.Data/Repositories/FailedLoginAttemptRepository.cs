using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class FailedLoginAttemptRepository(DataContext dataContext)
        : BaseRepository<FailedLoginAttempt, Guid>(dataContext), IFailedLoginAttemptRepository
    {
      


        public async Task<int> CountRecentFailedAttemptsByUserAsync(Guid idUsuario)
        {
            return await dataContext.Set<FailedLoginAttempt>()
                .Where(f => f.IdUsuario == idUsuario)
                .CountAsync();
        }

        public async Task<int> CountFailedAttemptsByLoginAsync(string login)
        {
            return await dataContext.Set<FailedLoginAttempt>()
                .Where(f => f.Login == login)
                .CountAsync();
        }

        public async Task ClearFailedAttemptsForUserAsync(Guid idUsuario)
        {
            var list = dataContext.Set<FailedLoginAttempt>().Where(f => f.IdUsuario == idUsuario);
            dataContext.Set<FailedLoginAttempt>().RemoveRange(list);
            await Task.CompletedTask;
        }

        public async Task RemoveUserAsync(Guid idUsuario)
        {
            await dataContext.FailedLoginAttempt
                .Where(x => x.IdUsuario == idUsuario)
                .ExecuteDeleteAsync();
        }

    }

}