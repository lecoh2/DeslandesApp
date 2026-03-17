using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class PessoaJuridica : Pessoa
    {

        public string CNPJ { get; set; } = string.Empty;
        public string InscricaoEstadual { get; set; } = string.Empty;
        public string InscricaoMunicipal { get; set; } = string.Empty;
        
        #region Relacionamento Enumeradores
       
        public SimplesNacional? SimplesNacional { get; set; }
        #endregion
        #region Relacionamento     
        // 🔥 ESSENCIAL PARA N:N
        public ICollection<GrupoPessoaClientes> GrupoPessoaClientes { get; set; }
        #endregion
    }
}
