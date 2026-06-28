using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.WebJur
{
    public class WebJurSincronizacaoResponse
    {
        public Guid Id { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime? Fim { get; set; }

        public bool Sucesso { get; set; }

        public string Mensagem { get; set; }
    }
}
