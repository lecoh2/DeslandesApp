using DeslandesApp.Domain.Models.Dtos.Requests.EnderecoPessoa;
using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Pessoas
{
    public record PessoaJuridicaUpdateRequest
   (       
        string? Cnpj,
        string? InscricaoEstadual,
        string? InscricaoMunicipal,
        int? IdEtiqueta,
        string? Email,
        string? Site,
        int? IdPerfil, 
        string? Telefone,
        Guid? IdUsuario,
       string? Observacoes,
    #region Relacionamentos
        EnderecoRequest? Endereco,
        InformacoesComplementaresRequest? InformacoesComplementares
    #endregion
    );
    
}
