using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Enum
{
    public enum TipoContaReceber
    {
        HonorarioContratual = 1,
        HonorarioExito = 2,
        Consulta = 3,
        Audiencia = 4,
        CustasReembolsaveis = 5,
        Mensalidade = 6,
        Outro = 99
    }
}
