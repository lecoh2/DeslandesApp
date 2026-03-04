using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Entities
{
    public class Endereco
    {
        
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cep { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
        public Guid? IdPessoa { get; set; }
       

        #region Relacionamento
        public virtual Pessoa? Pessoa { get; set; }

        #endregion
    }
}
