using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Dtos.Requests.Contrato;
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
    public class ContratoProcessoRepository(DataContext dataContext) : BaseRepository<ContratoProcesso, Guid>(dataContext), IContratoProcessoRepository
    {
        public async Task RemoverPorContratoIdAsync(Guid contratoId)
        {
            var registros = await dataContext.ContratoProcesso
                .Where(x => x.ContratoId == contratoId)
                .ToListAsync();

            dataContext.ContratoProcesso.RemoveRange(registros);
        }
        public async Task<List<ProcessoVinculadoContratoRequest>>
            VerificarProcessosJaVinculadosAsync(
                List<Guid> processosIds,
                Guid contratoAtualId)
        {
            return await dataContext.ContratoProcesso
                .Where(x =>
                    processosIds.Contains(x.ProcessoId) &&
                    x.ContratoId != contratoAtualId)
                .Select(x => new ProcessoVinculadoContratoRequest
                {
                    NumeroProcesso = x.Processo.NumeroProcesso,
                    NumeroContrato = x.Contrato.Numero
                })
                .ToListAsync();
        }
        public async Task<List<ProcessoVinculadoContratoRequest>>
       VerificarProcessosJaVinculadosAsync(List<Guid> processosIds)
        {
            return await dataContext.ContratoProcesso
                .Where(x => processosIds.Contains(x.ProcessoId))
                .Select(x => new ProcessoVinculadoContratoRequest
                {
                    NumeroProcesso = x.Processo.NumeroProcesso,
                    NumeroContrato = x.Contrato.Numero
                })
                .ToListAsync();
        }
    }
}
