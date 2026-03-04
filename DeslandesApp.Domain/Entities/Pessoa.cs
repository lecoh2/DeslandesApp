using DeslandesApp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Entities
{
    public abstract class Pessoa
    {
        public string Nome { get; set; } = string.Empty;
        //Enum Etiqueta RELACIONAR
        //Enum Perfil
        //Enum Telefone
        //Enum Email
        public string Apelido { get; set; } = string.Empty; 
        public string Telefone { get; set; } = string.Empty;
        public string Operadora { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Site { get; set; } = string.Empty;

        #region Relacionamento
        public Endereco? Endereco { get; set; }
        public InformacoesComplementares? InformacoesComplementares { get; set; }
        #endregion

        #region ENUMERADO STATUS
        public Etiqueta? Etiqueta { get; set; }
        public Perfil? Perfil { get; set; }
        public Telefone? TipoTelefone { get; set; }
        public Email? TipoEmail { get; set; }

        #endregion


    }
}
