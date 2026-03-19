using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Tarefa
{
    public record CriarListaTarefaRequest
    {
        public Guid ProcessoId { get; init; }

        // Responsável principal da lista (opcional)
        public Guid? ResponsavelId { get; init; }

        // Prioridade da lista, padrão Média
        public PrioridadeTarefa Prioridade { get; init; } = PrioridadeTarefa.Media;

        // Envolvidos específicos desta lista de tarefa
        public List<Guid> EnvolvidosIds { get; init; } = new List<Guid>();
    }
}

