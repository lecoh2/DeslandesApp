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

        // 🔗 Vinculos
        public Guid? ProcessoId { get; init; }
        public Guid? CasoId { get; init; }
        public Guid? AtendimentoId { get; init; }

        public Guid? UsuarioCriacaoId { get; init; }

        public PrioridadeTarefa Prioridade { get; init; }

        // 🔥 ADICIONAR
        public TipoVinculo? TipoVinculo { get; init; }

        // 🔥 CORRIGIR
        public StatusGeralKanban StatusGeralKanban { get; init; }

        // 🏷️ Etiquetas
        public List<GrupoTarefasEtiquetasRequest> GrupoTarefasEtiquetas { get; init; } = new();

        // 📋 Checklist
        public List<CriarListaTarefaRequest> ListasTarefa { get; init; } = new();

        // 👥 Envolvidos
        public List<GrupoTarefaResponsaveisRequest> GrupoTarefaResponsaveis { get; init; } = new();
    }
}
