using DeslandesApp.Domain.Models.Dtos.Responses.HistoricoGeral;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IHistoricoGeralService
    {
        Task RegistrarAsync(
            TipoEntidade entidade,
            Guid entidadeId,
            Guid? usuarioId,
            object dadosAntes,
            object dadosDepois,
            string? observacao = null

        );
        Task<List<HistoricoGeralResponse>> ObterPorEntidadeAsync(TipoEntidade entidade, Guid entidadeId);
    }
}
