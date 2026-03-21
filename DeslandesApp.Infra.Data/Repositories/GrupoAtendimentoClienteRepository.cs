using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class GrupoAtendimentoClienteRepository(DataContext dataContext)
        : BaseRepository<GrupoAtendimentoCliente, Guid>(dataContext), IGrupoAtendimentoClienteRepository
    {

    }
}
