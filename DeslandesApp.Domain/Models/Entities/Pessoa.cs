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
        //Enum Etiqueta RELACIONAR
        //Enum Perfil
        //Enum Telefone
 
        public string Apelido { get; set; } = string.Empty; 
        public string Telefone { get; set; } = string.Empty;
        public string Operadora { get; set; } = string.Empty;
        
        public string Site { get; set; } = string.Empty;
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public Guid? IdUsuarioCadastro { get; set; }
        public Guid? IdSexo { get; set; }
        #region Relacionamento
        public Endereco? Endereco { get; set; }
        public InformacoesComplementares? InformacoesComplementares { get; set; }
        public Sexo? Sexo { get; set; }
        public Usuario? Usuario { get; set; }            // Usuário vinculado
        public Usuario? UsuarioCadastro { get; set; }    // Usuário que cadastrou
        public Email? Email{ get; set; }              // Email principal vinculado
        #endregion

        #region ENUMERADO STATUS
        public Etiqueta? Etiqueta { get; set; }
        public Perfil? Perfil { get; set; }
        public Telefone? TipoTelefone { get; set; }
        public TipoConta? TipoEmail { get; set; }

        #endregion


    }
}
