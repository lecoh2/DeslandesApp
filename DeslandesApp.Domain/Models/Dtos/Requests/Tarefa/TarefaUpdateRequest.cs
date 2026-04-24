using DeslandesApp.Domain.Models.Dtos.Requests.GrupoTarefasEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoTarefasEtiquetas;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Tarefa
{
    public record TarefaUpdateRequest
    {
        public string? Descricao { get; init; }

        public DateTime? DataTarefa { get; init; }

        // 🔗 Vínculos
        public Guid? ProcessoId { get; init; }
        public Guid? CasoId { get; init; }
        public Guid? AtendimentoId { get; init; }

        public PrioridadeTarefa? Prioridade { get; init; }

        // 🏷️ Etiquetas
        public List<GrupoTarefasEtiquetasRequest>? GrupoTarefasEtiquetas { get; init; }

        // 📋 Checklist
        public List<CriarListaTarefaRequest>? ListasTarefa { get; init; }

        // 👥 Responsáveis
        public List<GrupoTarefaResponsaveisRequest>? GrupoTarefaResponsaveis { get; init; }
    }
}
