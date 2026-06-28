using DeslandesApp.Domain.Models.Dtos.Responses.Andamento;
using DeslandesApp.Domain.Models.Dtos.Responses.WebJur;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IWebJurService
    {
        /// <summary>
        /// Atualiza os andamentos de um processo específico consultando o tribunal.
        /// </summary>
        Task<bool> AtualizarProcessoAsync(Guid processoId);

        /// <summary>
        /// Sincroniza todos os processos cadastrados no sistema.
        /// </summary>
        Task SincronizarTodosProcessosAsync();

        /// <summary>
        /// Sincroniza apenas os processos marcados para monitoramento automático.
        /// </summary>
        Task SincronizarProcessosMonitoradosAsync();

        /// <summary>
        /// Consulta os andamentos de um processo (sem persistir).
        /// </summary>
        Task<List<AndamentoProcessoResponse>> ConsultarAndamentosAsync(Guid processoId);

        /// <summary>
        /// Verifica se o processo existe no tribunal antes de tentar sincronizar.
        /// </summary>
        Task<bool> VerificarProcessoExisteAsync(string numeroProcesso);

        Task ImportarPublicacoesAsync();
        Task<List<WebJurPublicacaoResponse>> ObterPublicacoesNaoExportadasAsync();
        Task<PageResult<WebJurPublicacaoResponse>> ConsultarPublicacoesPaginadasAsync(
    int pageNumber,
    int pageSize,
    string? searchTerm = null);


        Task<WebJurPublicacaoDetalheResponse> ObterDetalheAsync(Guid id);
        Task SincronizarPublicacaoAsync(Guid id);

        Task AdicionarComentarioAsync(Guid publicacaoId, WebJurComentarioResponse request);

        Task RegistrarVisualizacaoAsync(Guid publicacaoId);

        Task<(byte[] Conteudo, string NomeArquivo)> ObterPdfAsync(Guid id);

    }
}
