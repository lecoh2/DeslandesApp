using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IFailedLoginAttemptRepository
    {
        Task AddAsync(FailedLoginAttempt entity);
        Task<int> CountRecentFailedAttemptsByUserAsync(Guid idUsuario);
        Task<int> CountFailedAttemptsByLoginAsync(string login);
        Task ClearFailedAttemptsForUserAsync(Guid idUsuario);
        Task RemoveUserAsync(Guid idUsuario);
    }
}
