using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoPessoasEtiquetas
{
    public record GrupoPessoasEtiquetasResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
    }
}
