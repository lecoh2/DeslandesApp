using DeslandesApp.Domain.Models.Dtos.Responses.GrupoClienteProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEnvolvidosProcesso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Processo
{
    public record ProcessoResumoResponse
    {
        public Guid Id { get; init; }
        public string? Pasta { get; init; }
        public string? NumeroProcesso { get; init; }
        public string? Titulo { get; init; }

        public List<GrupoClienteProcessoResponse> GrupoClientesProcesso { get; init; } = new();
        public List<GrupoEnvolvidosProcessoResponse> GrupoEnvolvidosProcesso { get; init; } = new();

        public DateTime? DataCadastro { get; init; }
        public int Status { get; init; }
    }
}
