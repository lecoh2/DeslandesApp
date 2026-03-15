using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class PessoaHistorico : BaseEntity
    {
        //public Guid IdHistoricoPessoa { get; set; }
        public Guid IdPessoa { get; set; }
        public Guid? IdUsuario { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string? Observacoes { get; set; }

        //JSON bruto
        public string DadosAntes { get; set; } = string.Empty;
        public string DadosDepois { get; set; } = string.Empty;
        // Relacionamentos (opcional, se quiser consultar junto)
        public Pessoa? Pessoa { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
