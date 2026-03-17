using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Qualificacao : BaseEntity
    {
        public string NomeQualificacao { get; set; } = string.Empty;
        public Processo Processo { get; set; }
    }
}
