using DeslandesApp.Domain.Models.Dtos.Requests.Contrato;
using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{

    public interface IContratoProcessoRepository : IBaseRepository<ContratoProcesso, Guid>
    {
        Task RemoverPorContratoIdAsync(Guid contratoId);
        Task<List<ProcessoVinculadoContratoRequest>>
                VerificarProcessosJaVinculadosAsync(
                    List<Guid> processosIds,
                    Guid contratoAtualId);
        Task<List<ProcessoVinculadoContratoRequest>>
         VerificarProcessosJaVinculadosAsync(List<Guid> processosIds);




    }
}
