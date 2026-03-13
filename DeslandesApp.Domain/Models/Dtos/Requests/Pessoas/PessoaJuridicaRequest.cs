using DeslandesApp.Domain.Models.Dtos.Requests.EnderecoPessoa;
using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Pessoas
{
    public record PessoaJuridicaRequest
   (
        string? Nome,
        string? Cnpj,
        string? InscricaoEstadual,
        string? InscricaoMunicipal,
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
        Guid? IdUsuario,
        Guid? IdSexo,

        #region Relacionamentos
        EnderecoRequest? Endereco,
        InformacoesComplementaresRequest? InformacoesComplementares
    #endregion
    );
    
}
