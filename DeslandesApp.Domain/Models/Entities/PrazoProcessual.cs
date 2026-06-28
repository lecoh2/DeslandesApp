using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class PrazoProcessual : BaseEntity
    {
        public Guid ProcessoId { get; set; }

        public Processo Processo { get; set; }

        public string Descricao { get; set; }

        public DateOnly DataVencimento { get; set; }

        public bool Concluido { get; set; }

        public Guid ResponsavelId { get; set; }

        public Usuario Responsavel { get; set; }
    }
}
