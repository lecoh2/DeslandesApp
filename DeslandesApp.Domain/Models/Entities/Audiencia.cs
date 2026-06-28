using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Audiencia : BaseEntity
    {
        public Guid ProcessoId { get; set; }
        public Processo Processo { get; set; } = null!;

        public DateTime DataHora { get; set; }

        public TipoAudiencia Tipo { get; set; }

        public StatusAudiencia Status { get; set; }

        public string? Local { get; set; }

        public string? LinkVideoconferencia { get; set; }

        public string? Magistrado { get; set; }

        public string? Observacao { get; set; }

        public string? Resultado { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}
