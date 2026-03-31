using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IGrupoCasoClienteRepository : IBaseRepository<GrupoCasoCliente, Guid>
    {
        Task<GrupoCasoCliente> GetByIdClienteAsync(Guid idPessoa, Guid idCaso );
        Task<GrupoCasoCliente> ExistCasoClienteAsync(Guid idPessoa, Guid idCaso);
    }
}

