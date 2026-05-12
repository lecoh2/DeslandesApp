using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Usuario : BaseEntity
    {
        //public Guid IdUsuario { get; set; }
        public string? NomeUsuario { get; set; } = string.Empty;
        public string? Login { get; set; } = string.Empty;
        public string? Senha { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        #region Relacionamentos

        public List<Pessoa>? Pessoa { get; set; }
        public Status? Status { get; set; }
        public ICollection<GrupoSetores> GrupoSetores { get; set; }
            = new List<GrupoSetores>();
        public ICollection<GrupoNiveis> GrupoNiveis { get; set; }
            = new List<GrupoNiveis>();

        public virtual Fotos? Fotos { get; set; }
        public ValorEmail? ValorEmail { get; set; }
        public ICollection<Processo> ProcessosResponsaveis { get; set; }
            = new List<Processo>();
        public ICollection<GrupoTarefaResponsaveis> GrupoTarefaResponsaveis { get; set; }
            = new List<GrupoTarefaResponsaveis>();


        #endregion
    }
}
