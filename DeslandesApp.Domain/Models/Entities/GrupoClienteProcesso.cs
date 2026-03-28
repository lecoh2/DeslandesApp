using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class GrupoClienteProcesso
    {
        
            public Guid PessoaId { get; set; }
            public Guid ProcessoId { get; set; }
            // public Guid IdNivel { get; set; }

            public Pessoa Pessoa { get; set; }
            public Processo Processo { get; set; }
        // public Niveis Nivel { get; set; }
       
    }
}
