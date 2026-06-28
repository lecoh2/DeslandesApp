using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Responses.WebJur;
using DeslandesApp.Domain.Models.Entities;
using ServiceReference1;


namespace DeslandesApp.Infra.Data.ExternalServices
{
    public class TribunalClient : ITribunalClient
    {
        private readonly wsPublicacaoSoapClient _client;

        public TribunalClient()
        {
            _client = new wsPublicacaoSoapClient(
                wsPublicacaoSoapClient.EndpointConfiguration.wsPublicacaoSoap
            );
        }

        public async Task<List<WebJurPublicacaoResponse>> ObterPublicacoesNaoExportadasAsync()
        {
            var request = new getPublicacoesNaoExportadasRequest
            {
                strUsuario = "LUIZ",
                strSenha = "90860783",
                intCodGrupo = 0
            };

            var response = await _client.getPublicacoesNaoExportadasAsync(request);

            // 🔥 AQUI está o ponto certo AGORA CONFIRMADO PELO SEU CÓDIGO
            var lista = response.getPublicacoesNaoExportadasResult?.publicacao;

            if (lista == null || lista.Length == 0)
                return new List<WebJurPublicacaoResponse>();

            return lista.Select(x =>
            {
          
                DateTime.TryParse(x.dataPublicacao, out var dataPublicacao);
                DateTime.TryParse(x.dataCadastro, out var dataCadastro);

                return new WebJurPublicacaoResponse
                {
                    CodPublicacao = (int)x.codPublicacao,
                    NumeroProcesso = x.numeroProcesso,
                    DataPublicacao = dataPublicacao,
                    DataCadastro = dataCadastro,
                    DespachoPublicacao = x.despachoPublicacao,
                    ProcessoPublicacao = x.processoPublicacao,
                    VaraDescricao = x.varaDescricao,
                    OrgaoDescricao = x.orgaoDescricao,
                    PublicacaoCorrigida = x.publicacaoCorrigida == 1
                };
            }).ToList();
        }
        public Task<List<AndamentoProcesso>> ConsultarAndamentosAsync(string numeroProcesso)
        {
            return Task.FromResult(new List<AndamentoProcesso>());
        }

        public Task<bool> VerificarProcessoExisteAsync(string numeroProcesso)
        {
            return Task.FromResult(!string.IsNullOrEmpty(numeroProcesso));
        }
        public async Task SetPublicacoesAsync(string codigos)
        {
            var request = new setPublicacoesRequest
            {
                strUsuario = "LUIZ",
                strSenha = "90860783",
                strPublicacoes = codigos
            };

            var response = await _client.setPublicacoesAsync(request);

            if (response.setPublicacoesResult != 1)
            {
                throw new Exception($"WebJur retornou erro ao marcar publicações. Código: {response.setPublicacoesResult}");
            }
        }
    }
}