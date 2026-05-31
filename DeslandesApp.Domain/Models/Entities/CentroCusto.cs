using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class CentroCusto : BaseEntity
    {
        public string Nome { get; set; }

        public string? Descricao { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
