using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiqueta;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoTarefasEnvolvidos;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Tarefa
{
    public record CriarTarefaRequest
    {
        public string Descricao { get; init; } = string.Empty;

        public DateTime? DataTarefa { get; init; }

        // 🔗 Vínculo (opcional)
        public Guid? VinculoId { get; init; }
        public TipoVinculo? TipoVinculo { get; init; }

        // 👤 Responsável (opcional)
        public Guid? ProcessoId { get; init; }
        public Guid? CasoId { get; init; }
        public Guid? AtendimentoId { get; init; }
        public Guid? ResponsavelId { get; init; }

        public PrioridadeTarefa Prioridade { get; init; }

        // 🏷️ Etiquetas
        public List<GrupoEtiquetaRequest> Etiquetas { get; init; } = new();

        // 📋 Checklist
        public List<CriarListaTarefaRequest> ListasTarefa { get; init; } = new();

        // 👥 Envolvidos
        public List<GrupoTarefaEnvolvidosRequest> GrupoTarefaEnvolvido { get; init; } = new();
    }
}
