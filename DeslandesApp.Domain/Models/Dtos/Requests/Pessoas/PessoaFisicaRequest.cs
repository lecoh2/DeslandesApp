using DeslandesApp.Domain.Models.Dtos.Requests.EnderecoPessoa;
using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;
using DeslandesApp.Domain.Models.Dtos.Requests.Sexo;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Pessoas
{
    public class PessoaFisicaRequest
    {
        public string? Nome { get; set; }
      
        public int? IdEtiqueta { get; set; }
        public string? Email { get; set; }
        public string? Site { get; set; }
        public int? IdPerfil { get; set; }
        public string? Rg { get; set; }
        public string? Cpf { get; set; }
        public string? TituloEleitor { get; set; }
        public string? CarteiraTrabalho { get; set; }
        public string? PisPasep { get; set; }
        public string? CNH { get; set; }
        public string? Passaporte { get; set; }
        public string? CertidaoReservist { get; set; }
        public string? Telefone { get; set; }
      
        public DateTime DataCadastro { get; set; }        
        public Guid? IdUsuarioCadastro { get; set; }
        public Guid? IdSexo { get; set; }
        public int? IdTipoConta { get; set; }
    
        #region Relacionamento
        public EnderecoRequest? Endereco { get; set; }
        public InformacoesComplementaresRequest? InformacoesComplementares { get; set; }
        //public SexoRequest? Sexo { get; set; }   
     
        #endregion

       
    }
}
