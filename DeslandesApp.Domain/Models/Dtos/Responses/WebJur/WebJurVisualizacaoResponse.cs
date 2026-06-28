using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.WebJur
{
    public class WebJurVisualizacaoResponse
    {
        public Guid Id { get; set; }

        public string Usuario { get; set; }

        public DateTime DataVisualizacao { get; set; }
    }
}
