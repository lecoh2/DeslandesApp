using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.WebJur
{
    public class WebJurComentarioResponse
    {
        public Guid Id { get; set; }

        public string Usuario { get; set; }

        public string Comentario { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
