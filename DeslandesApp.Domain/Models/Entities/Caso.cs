using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Caso : BaseEntity
    {
        public string Pasta { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string? Observacao { get; set; }

        // Responsável
        public Guid? ResponsavelId { get; set; }
        public Pessoa? Responsavel { get; set; }

        // Acesso
        public AcessoCaso Acesso { get; set; } = AcessoCaso.Publico;

        // Clientes e Envolvidos
        public List<GrupoCasoCliente> GrupoCasoCliente { get; set; } = new List<GrupoCasoCliente>();
        public List<GrupoCasoEnvolvido> GrupoCasoEnvolvido { get; set; } = new List<GrupoCasoEnvolvido>();

    }
}
