using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Evento
{
    public record CriarEventoRequest
 (
     string Titulo,

     DateOnly DataInicial,
     TimeOnly HoraInicial,

     DateOnly? DataFinal,
     TimeOnly? HoraFinal,

     bool DiaInteiro,

     string? Endereco,

     ModalidadeEvento Modalidade,

     string? Observacao,

     // 👥 Responsáveis (N:N)
     List<Guid>? ResponsaveisIds,

     // 🔁 Recorrência
     TipoRecorrencia TipoRecorrencia,
     int IntervaloRecorrencia,
     List<DayOfWeek>? DiasSemana,
     DateOnly? DataFimRecorrencia,
     int? QuantidadeOcorrencias
 );
}
