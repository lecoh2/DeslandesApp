using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoEnvolvidos;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Caso
{
    public record CriarCasoRequest
    {
        public string Pasta { get; init; } = string.Empty;
        public string Titulo { get; init; } = string.Empty;
        public string Descricao { get; init; } = string.Empty;
        public string? Observacao { get; init; }
        public Guid? ResponsavelId { get; init; }
        public AcessoCaso Acesso { get; init; } = AcessoCaso.Publico;

        public List<GrupoCasoClienteRequest> GrupoCasoClientes { get; init; } = new List<GrupoCasoClienteRequest>();
        public List<GrupoCasoEnvolvidosRequest> GrupoCasoEnvolvidos { get; init; } = new List<GrupoCasoEnvolvidosRequest>();
    }
}
