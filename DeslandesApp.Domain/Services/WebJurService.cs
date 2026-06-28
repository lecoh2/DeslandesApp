using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.WebJur;
using DeslandesApp.Domain.Models.Dtos.Responses.Andamento;
using DeslandesApp.Domain.Models.Dtos.Responses.WebJur;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using Microsoft.AspNetCore.Http;

namespace DeslandesApp.Domain.Services
{
    public class WebJurService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ITribunalClient tribunalClient,
        IHttpContextAccessor httpContextAccessor,
        IHistoricoGeralService historicoGeralService,
        INotificacaoService notificacaoService
    ) : BaseService(httpContextAccessor), IWebJurService
    {

        public async Task<bool> AtualizarProcessoAsync(Guid processoId)
        {
            var processo = await unitOfWork.ProcessoRepository
                .ObterPorIdAsync(processoId);

            if (processo == null)
                return false;

            // ✔ FONTE EXTERNA (TRIBUNAL)
            var andamentosTribunal = await tribunalClient
                .ConsultarAndamentosAsync(processo.NumeroProcesso); 
            Console.WriteLine($"Andamentos encontrados: {andamentosTribunal.Count}");

            if (andamentosTribunal == null || !andamentosTribunal.Any())
            {
                processo.UltimaConsultaTribunal = DateTime.UtcNow;
                await unitOfWork.CommitAsync();
                return true;
            }

            foreach (var andamento in andamentosTribunal)
            {
                var existe = await unitOfWork.AndamentoProcessoRepository
                    .ExisteAsync(
                        processoId,
                        andamento.DataMovimentacao,
                        andamento.Descricao
                    );

                if (!existe)
                {
                    var entity = new AndamentoProcesso
                    {
                        ProcessoId = processoId,
                        DataMovimentacao = andamento.DataMovimentacao,
                        Descricao = andamento.Descricao,
                        Complemento = andamento.Complemento,
                        Origem = string.IsNullOrEmpty(andamento.Origem)
                            ? "TRIBUNAL"
                            : andamento.Origem,
                        CapturadoAutomaticamente = true,
                        DataCadastro = DateTime.Now
                    };


                    await unitOfWork.AndamentoProcessoRepository
                        .AdicionarAsync(entity);
                }
            }

            processo.UltimaConsultaTribunal = DateTime.UtcNow;
            processo.UltimoAndamentoCapturado = DateTime.UtcNow;

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<List<AndamentoProcessoResponse>> ConsultarAndamentosAsync(Guid processoId)
        {
           
            var dados = await unitOfWork.AndamentoProcessoRepository
                .ObterPorProcessoIdAsync(processoId);

            return mapper.Map<List<AndamentoProcessoResponse>>(dados);
        }

        public async Task SincronizarProcessosMonitoradosAsync()
        {
            var processos = await unitOfWork.ProcessoRepository
                .ObterMonitoradosAsync();

            foreach (var processo in processos)
            {
                await AtualizarProcessoAsync(processo.Id);
            }
        }

        public async Task SincronizarTodosProcessosAsync()
        {
            var processos = await unitOfWork.ProcessoRepository
                .ObterTodosAsync();

            foreach (var processo in processos)
            {
                await AtualizarProcessoAsync(processo.Id);
            }
        }

        public async Task<bool> VerificarProcessoExisteAsync(string numeroProcesso)
        {
            return await tribunalClient
                .VerificarProcessoExisteAsync(numeroProcesso);
        }
        public async Task ImportarPublicacoesAsync()
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var publicacoes = await tribunalClient
                    .ObterPublicacoesNaoExportadasAsync();

                if (publicacoes == null || !publicacoes.Any())
                    return;

                var codigosExistentes = (await unitOfWork.WebJurPublicacaoRepository
                    .ObterCodigosExistentesAsync(
                        publicacoes.Select(x => x.CodPublicacao).ToList()
                    ))
                    .ToHashSet();

                int importadas = 0;
                int falhas = 0;

                foreach (var publicacao in publicacoes)
                {
                    try
                    {
                        if (codigosExistentes.Contains(publicacao.CodPublicacao))
                            continue;

                        var processo = await unitOfWork.ProcessoRepository
                            .ObterPorNumeroAsync(publicacao.NumeroProcesso);

                        var entity = new WebJurPublicacao
                        {
                            CodPublicacao = publicacao.CodPublicacao,
                            NumeroProcesso = publicacao.NumeroProcesso,
                            DataPublicacao = publicacao.DataPublicacao,
                            DataCadastroWebJur = publicacao.DataCadastro,
                            DespachoPublicacao = publicacao.DespachoPublicacao,
                            ProcessoPublicacao = publicacao.ProcessoPublicacao,
                            VaraDescricao = publicacao.VaraDescricao,
                            OrgaoDescricao = publicacao.OrgaoDescricao,
                            PublicacaoCorrigida = publicacao.PublicacaoCorrigida,
                            Importada = true,
                            ProcessoId = processo?.Id
                        };

                        await unitOfWork.WebJurPublicacaoRepository
                            .AddAsync(entity);

                        importadas++;

                        if (processo != null)
                        {
                            await unitOfWork.AndamentoProcessoRepository
                                .AdicionarAsync(new AndamentoProcesso
                                {
                                    ProcessoId = processo.Id,
                                    DataMovimentacao = publicacao.DataPublicacao,
                                    Descricao = publicacao.DespachoPublicacao,
                                    Origem = "WEBJUR",
                                    CapturadoAutomaticamente = true,
                                    DataCadastro = DateTime.Now
                                });

                            // 🔔 NOTIFICAÇÃO AQUI (NOVO)
                            var responsavelId = processo.UsuarioResponsavelId; // ajuste se o nome for outro

                            if (responsavelId != null)
                            {
                                await notificacaoService.CriarNotificacaoAsync(
                                    responsavelId.Value,
                                    "Nova publicação importada",
                                    $"Processo {publicacao.NumeroProcesso} teve nova movimentação",
                                    TipoEntidade.Processo,
                                    processo.Id
                                );
                            }
                        }
                    }
                    catch
                    {
                        falhas++;
                    }
                }

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task<List<WebJurPublicacaoResponse>> ObterPublicacoesNaoExportadasAsync()
        {
            return await tribunalClient.ObterPublicacoesNaoExportadasAsync();
        }
        private async Task MarcarPublicacoesComoExportadasAsync(List<string> codigos)
        {
            if (!codigos.Any())
                return;

            var payload = string.Join("|", codigos);

            await tribunalClient.SetPublicacoesAsync(payload);
        }
        public async Task<PageResult<WebJurPublicacaoResponse>> ConsultarPublicacoesPaginadasAsync(
    int pageNumber,
    int pageSize,
    string? searchTerm = null)
        {
            return await unitOfWork.WebJurPublicacaoRepository
                .GetPaginacaoAsync(pageNumber, pageSize, searchTerm);
        }

        public async Task<WebJurPublicacaoDetalheResponse> ObterDetalheAsync(Guid id)
        {
            var entity = await unitOfWork
                .WebJurPublicacaoRepository
                .ObterDetalheAsync(id);

            if (entity == null)
                throw new ApplicationException("Publicação não encontrada.");

            return mapper.Map<WebJurPublicacaoDetalheResponse>(entity);
        }
        public async Task SincronizarPublicacaoAsync(Guid id)
        {
            var publicacao = await unitOfWork.WebJurPublicacaoRepository
                .GetByIdAsync(id);

            if (publicacao == null)
                throw new ApplicationException("Publicação não encontrada.");

            publicacao.Importada = true;
            publicacao.DataCadastroWebJur = DateTime.Now;

            await unitOfWork.WebJurPublicacaoRepository.UpdateAsync(publicacao);

            await unitOfWork.CommitAsync();
        }
        public async Task AdicionarComentarioAsync(Guid publicacaoId, WebJurComentarioRequest request)
        {
            var publicacao = await unitOfWork.WebJurPublicacaoRepository
                .GetByIdAsync(publicacaoId);

            if (publicacao == null)
                throw new ApplicationException("Publicação não encontrada.");
            var usuarioId = ObterUsuarioId();

            if (!usuarioId.HasValue)
                throw new ApplicationException("Usuário não autenticado.");
            var comentario = new WebJurComentario
            {
                Id = Guid.NewGuid(),
                WebJurPublicacaoId = publicacaoId,
                Comentario = request.Comentario,
                DataCadastro = DateTime.Now,
                UsuarioId = usuarioId.Value // já existe no seu BaseService
            };

            await unitOfWork.WebJurComentarioRepository
                .AdicionarAsync(comentario);

            await unitOfWork.CommitAsync();
        }
        public async Task RegistrarVisualizacaoAsync(Guid publicacaoId)
        {
            var usuarioId = ObterUsuarioId();

            if (!usuarioId.HasValue)
                throw new ApplicationException("Usuário não autenticado.");

            var ip =
                _httpContextAccessor.HttpContext?.Request.Headers["X-Forwarded-For"].FirstOrDefault()
                ?? _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString()
                ?? "unknown";

            var visualizacao = new WebJurVisualizacao
            {
                Id = Guid.NewGuid(),
                WebJurPublicacaoId = publicacaoId,
                UsuarioId = usuarioId.Value,
                DataVisualizacao = DateTime.Now,
                Ip = ip // 🔥 AQUI
            };

            await unitOfWork.WebJurVisualizacaoRepository
                .AdicionarAsync(visualizacao);

            await unitOfWork.CommitAsync();
        }
        public async Task<(byte[] Conteudo, string NomeArquivo)> ObterPdfAsync(Guid id)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes("PDF ainda não implementado");

            return (bytes, $"publicacao-{id}.pdf");
        }

        public Task AdicionarComentarioAsync(Guid publicacaoId, WebJurComentarioResponse request)
        {
            throw new NotImplementedException();
        }
    }
}