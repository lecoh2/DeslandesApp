using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Caso
{
    public class CasoAutoComplete
    {
        public Guid? Id { get; set; }
        public string Titulo { get; init; }
    }
}
