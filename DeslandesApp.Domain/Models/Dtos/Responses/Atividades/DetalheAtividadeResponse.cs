using DeslandesApp.Domain.Models.Dtos.Responses.Etiquetas;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Atividades
{
    public record DetalheAtividadeResponse
    {
        public Guid Id { get; init; }
        public string Titulo { get; init; }
        public string Status { get; init; }
        public DateTime? DataInicio { get; init; }
        public DateTime? DataFim { get; init; }
        public string? Modalidade { get; init; }
        public string? Endereco { get; init; }
        public string? CriadoPor { get; init; }
        public PrioridadeTarefa Prioridade { get; set; }
        public List<UsuarioResumoResponse> Responsaveis { get; init; } = new();
        public List<EtiquetaResponse> Etiquetas { get; init; } = new();
        public string Tipo { get; init; }
    }
}
