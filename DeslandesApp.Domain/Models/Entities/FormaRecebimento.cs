using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public enum FormaRecebimento
    {
        Dinheiro = 1,
        Pix = 2,
        CartaoCredito = 3,
        CartaoDebito = 4,
        Boleto = 5,
        Transferencia = 6,
        Deposito = 7
    }
}
