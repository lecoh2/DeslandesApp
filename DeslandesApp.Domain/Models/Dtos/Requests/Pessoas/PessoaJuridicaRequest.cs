using DeslandesApp.Domain.Models.Dtos.Requests.ContaBancaria;
using DeslandesApp.Domain.Models.Dtos.Requests.EnderecoPessoa;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoPessoasEtiquetas;
using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Pessoas
{
    public record PessoaJuridicaRequest
    {
        public string? Nome { get; set; }
        public string? Cnpj { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? InscricaoMunicipal { get; set; }
        public string? Email { get; set; }
        public string? Site { get; set; }
        public int? IdPerfil { get; set; }
        public string? Telefone { get; set; }
        public Guid? IdUsuario { get; set; }

        #region Relacionamentos
        public EnderecoRequest? Endereco { get; set; }
        public InformacoesComplementaresJuridicaRequest? InformacoesComplementares { get; set; }
        public List<GrupoPessoasEtiquetasRequest> GrupoPessoasEtiquetas { get; init; } = new();
        public ContaBancariaRequest? ContaBancaria { get; set; }
        #endregion
    }

}
