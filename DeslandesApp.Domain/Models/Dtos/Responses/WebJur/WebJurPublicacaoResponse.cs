using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.WebJur
{
    public class WebJurPublicacaoResponse
    {
        public Guid Id { get; set; }
        public int CodPublicacao { get; set; }

        public string NumeroProcesso { get; set; }

        public DateTime DataPublicacao { get; set; }

        public DateTime DataCadastro { get; set; }

        public string DespachoPublicacao { get; set; }

        public string ProcessoPublicacao { get; set; }

        public string VaraDescricao { get; set; }

        public string OrgaoDescricao { get; set; }

        public bool PublicacaoCorrigida { get; set; }
    }
}
