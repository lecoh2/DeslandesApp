using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IGrupoEventoResponsavelRepository : IBaseRepository<GrupoEventoResponsavel, Guid>
    {
        Task<GrupoEventoResponsavel> GetByIdEventoResponsaveisAsync(Guid idEvento, Guid idUsuario);
        Task<GrupoEventoResponsavel> ExistEventoResponsaveisAsync(Guid idEvento, Guid idUsuario);
    }
}
