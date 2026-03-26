using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Tarefa
{
    public record TarefaPaginacaoResponse
    {
        public Guid? Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime? DataTarefa { get; set; } 
        public UsuarioResumoResponse? Responsavel { get; set; }
        public PrioridadeTarefa? Prioridade { get; set; }
      
        public TipoVinculo? TipoVinculo { get; set; }
        public StatusGeralKanban? StatusGeralKanban { get; set; } 
    }
}
