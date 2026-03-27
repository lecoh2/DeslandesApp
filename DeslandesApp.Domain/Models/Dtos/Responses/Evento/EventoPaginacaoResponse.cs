using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEventoResponsavel;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Evento
{
    public record EventoPaginacaoResponse
    {
        public string Titulo { get; set; } = string.Empty;
        public DateOnly DataInicial { get; set; }
        public TimeOnly HoraInicial { get; set; }
        public DateOnly? DataFinal { get; set; }
        public TimeOnly? HoraFinal { get; set; }
        public bool DiaInteiro { get; set; }
        public string? Endereco { get; set; }
        public ModalidadeEvento Modalidade { get; set; } 
        public List<GrupoEventoResponsavelResponse> GrupoEventoResponsavel { get; set; } 
      
        public StatusGeralKanban StatusGeralKanban { get; set; }     

        public UsuarioResumoResponse? UsuarioCriacao { get; set; } 
    
    }
}
