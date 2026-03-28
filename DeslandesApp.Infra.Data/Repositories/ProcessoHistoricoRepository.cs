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
    public class ProcessoHistoricoRepository(DataContext dataContext)
        : BaseRepository<ProcessoHistorico, Guid>(dataContext), IProcessoHistoricoRepository
    {
        public async Task<List<ProcessoHistorico>> ConsultarProcessoHistoricoComRelacionamentosAsync(Guid id)
        {
            return await dataContext.ProcessoHistorico
               
                .Include(h => h.Usuario) // Usuário que fez a alteração
                    .ThenInclude(u => u.Pessoa)                
                .Include(h => h.Processo)//  Processo (somente relacionamentos diretos)
                    .ThenInclude(p => p.Vara)

                .Include(h => h.Processo)
                    .ThenInclude(p => p.UsuarioResponsavel)

                .Include(h => h.Processo)
                    .ThenInclude(p => p.Acao)                
                .Where(h => h.ProcessoId == id)//  filtro

             
                .OrderByDescending(h => h.DataAlteracao)   //  ordenação
                .ToListAsync();
        }
    }
}
