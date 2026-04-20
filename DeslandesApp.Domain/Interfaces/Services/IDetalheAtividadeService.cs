using DeslandesApp.Domain.Models.Dtos.Responses.Atividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IDetalheAtividadeService
    {
        Task<DetalheAtividadeResponse> ObterDetalhesAsync(Guid id, string tipo);
    }
}
