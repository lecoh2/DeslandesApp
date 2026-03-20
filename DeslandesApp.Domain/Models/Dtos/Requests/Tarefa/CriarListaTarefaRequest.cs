using DeslandesApp.Domain.Models.Dtos.Requests.GrupoTarefasEnvolvidos;
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
        public Guid VinculoId { get; init; }

        public TipoVinculo TipoVinculo { get; init; }

        public Guid? ResponsavelId { get; init; }

        public PrioridadeTarefa Prioridade { get; init; }

        // Envolvidos específicos desta lista de tarefa
        //public List<Guid> EnvolvidosIds { get; init; } = new List<Guid>();
        public List<GrupoTarefaEnvolvidosRequest> GrupoTarefaEnvolvido { get; init; }


    }
}

