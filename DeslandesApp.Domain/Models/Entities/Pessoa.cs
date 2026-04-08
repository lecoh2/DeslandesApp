using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public abstract class Pessoa : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;    
        public string Apelido { get; set; } = string.Empty; 
        public string Telefone { get; set; } = string.Empty;               
        public string Site { get; set; } = string.Empty;
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }       
        public Guid? IdSexo { get; set; }
        public Guid? IdUsuario { get; set; }
        #region Relacionamento
        public Endereco? Endereco { get; set; }
        public InformacoesComplementares? InformacoesComplementares { get; set; }
        public ICollection<GrupoPessoaClientes> GrupoPessoaClientes { get; set; }
        public ICollection<GrupoClienteProcesso> GrupoClienteProcesso { get; set; }
        public ICollection<GrupoEnvolvidosProcesso> GrupoEnvolvidosProcesso { get; set; }
        public ICollection<GrupoEtiquetasProcessos> GrupoEtiquetasProcessos { get; set; }
        public ICollection<GrupoEnvolvidos> GrupoEnvolvidos { get; set; }
        public ICollection<GrupoTarefaResponsaveis> GrupoTarefaResponsaveis { get; set; }
        public ICollection<ContaBancaria> ContasBancarias { get; set; } = new List<ContaBancaria>();
        public Sexo? Sexo { get; set; }
        public Usuario? Usuario { get; set; }            // Usuário vinculado
       // public Usuario? UsuarioCadastro { get; set; }    // Usuário que cadastrou
        public ValorEmail? ValorEmail { get; set; }              // Email principal vinculado
        #endregion

        #region ENUMERADO STATUS
        public List<GrupoPessoasEtiquetas> GrupoPessoasEtiquetas { get; set; } = new();
        public Perfil? Perfil { get; set; }
        public TipoConta? TipoConta { get; set; }

        #endregion


    }
}
