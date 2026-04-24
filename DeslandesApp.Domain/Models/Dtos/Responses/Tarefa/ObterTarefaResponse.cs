using DeslandesApp.Domain.Models.Dtos.Requests.GrupoTarefaResponsavel;
using DeslandesApp.Domain.Models.Dtos.Responses.Etiquetas;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoTarefaResponsaveis;
using DeslandesApp.Domain.Models.Dtos.Responses.ListaTarefas;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Tarefa
{
    public record ObterTarefaResponse
    {
        public Guid Id { get; init; }
        public string Descricao { get; init; }
        public DateTime? DataTarefa { get; init; }
        public StatusGeralKanban StatusGeralKanban { get; init; }
        public PrioridadeTarefa Prioridade { get; init; }

        public List<ListaTarefasResponse> ListasTarefa { get; init; }
        public List<TarefaResponsavelResponse> GrupoTarefaResponsaveis { get; init; }
        public List<EtiquetaResponse> GrupoTarefasEtiquetas { get; init; }
    }
}
