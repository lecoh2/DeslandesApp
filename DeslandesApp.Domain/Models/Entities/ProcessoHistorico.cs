using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class ProcessoHistorico : BaseEntity
    {
        //public Guid IdHistoricoPessoa { get; set; }
        public Guid IdProcesso { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdAcao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string? Observacoes { get; set; }    
        public Processo Processo { get; set; }
        //JSON bruto
        public string DadosAntes { get; set; } = string.Empty;
        public string DadosDepois { get; set; } = string.Empty;
        // Relacionamentos (opcional, se quiser consultar junto)
        public Acao? Acao { get; set; }

        public Usuario? Usuario { get; set; }
    }
}
