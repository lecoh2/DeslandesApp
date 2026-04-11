using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.ContaBancaria
{
    public record ContaBancariaRequest
    {
        public string? NomeBanco { get; init; }
        public string? Agencia { get; init; }
        public string? NumeroConta { get; init; }
        public string? Pix { get; init; }
        public TipoConta? TipoConta{ get; init; }
    }
}
