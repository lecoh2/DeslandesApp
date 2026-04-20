using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IKanbanService
    {
        Task<List<KanbanColuna>> ObterKanbanAsync();
        Task AtualizarStatusAsync(Guid id, StatusGeralKanban status);
    }
}
