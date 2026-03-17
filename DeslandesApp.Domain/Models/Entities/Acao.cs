using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Acao : BaseEntity
    {
        public string NomeAcao { get; set; } = string.Empty;
    }
}
