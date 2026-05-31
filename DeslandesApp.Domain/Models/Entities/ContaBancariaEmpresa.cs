using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class ContaBancariaEmpresa : BaseEntity
    {
        public string Banco { get; set; }

        public string Agencia { get; set; }

        public string Conta { get; set; }

        public string? Digito { get; set; }

        public decimal SaldoInicial { get; set; }

        public bool Ativa { get; set; } = true;
    }
}
