using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Processo
{
    public class ProcessoAutoComplete
    {
       public Guid Id { get; set; }
        public string? Pasta { get; set; }
        public string NumeroProcesso { get; set; }
        public string? Titulo { get; set; }
    }
}
