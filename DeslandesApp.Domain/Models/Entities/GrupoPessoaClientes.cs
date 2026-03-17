using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class GrupoPessoaClientes
    {
        public Guid IdPessoa { get; set; }
        public Guid IdProcesso { get; set; }
        public Pessoa? Pessoa{get;set;}
        public Processo? Processo { get; set; }
    }
}
