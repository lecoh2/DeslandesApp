using DeslandesApp.Domain.Models.Dtos.Requests.EnderecoPessoa;
using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Pessoas
{
    public record PessoaFisicaRequest
    (
        string? Nome,
        string? Apelido,
        int? IdEtiqueta,
        string? Email,
        string? Site,
        int? IdPerfil,
        string? Rg,
        string? Cpf,
        string? TituloEleitor,
        string? CarteiraTrabalho,
        string? PisPasep,
        string? CNH,
        string? Passaporte,
        string? CertidaoReservista,
        string? Telefone,
        Guid? IdUsuarioCadastro,
        Guid? IdSexo,

    #region Relacionamentos
        EnderecoRequest? Endereco,
        InformacoesComplementaresRequest? InformacoesComplementares
    #endregion
    );
}