using DeslandesApp.Domain.Models.Dtos.Responses.WebJur;
using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface ITribunalClient
    {
        Task<List<AndamentoProcesso>> ConsultarAndamentosAsync(string numeroProcesso);
        Task<List<WebJurPublicacaoResponse>>
    ObterPublicacoesNaoExportadasAsync();

        Task<bool> VerificarProcessoExisteAsync(string numeroProcesso);
        Task SetPublicacoesAsync(string codigos);
    }
}
