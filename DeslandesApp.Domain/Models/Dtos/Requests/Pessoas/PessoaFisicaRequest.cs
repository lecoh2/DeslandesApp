using DeslandesApp.Domain.Models.Dtos.Requests.EnderecoPessoa;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiquetaProcesso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoPessoasEtiquetas;
using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Pessoas
{
    public record PessoaFisicaRequest
    {
        public string? Nome { get; init; }
        public string? Apelido { get; init; }
       
        public string? Email { get; init; }
        public string? Site { get; init; }
        public int? IdPerfil { get; init; }
        public string? Rg { get; init; }
        public string? Cpf { get; init; }
        public string? TituloEleitor { get; init; }
        public string? CarteiraTrabalho { get; init; }
        public string? PisPasep { get; init; }
        public string? CNH { get; init; }
        public string? Passaporte { get; init; }
        public string? CertidaoReservista { get; init; }
        public string? Telefone { get; init; }
        public Guid? IdUsuario { get; init; }
        public Guid? IdSexo { get; init; }

        #region Relacionamentos
        public EnderecoRequest? Endereco { get; init; }
        public InformacoesComplementaresRequest? InformacoesComplementares { get; init; }
        public List<GrupoPessoasEtiquetasRequest> GrupoPessoasEtiquetas { get; init; } = new();
        #endregion
    }
}