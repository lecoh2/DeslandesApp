using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.WebJur
{
    public class WebJurPublicacaoDetalheResumoResponse
    {
        public Guid Id { get; set; }
        public int CodPublicacao { get; set; }
        public string NumeroProcesso { get; set; }
        public string TipoPublicacao { get; set; }
        public string VaraDescricao { get; set; }
        public string OrgaoDescricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string TextoPublicacao { get; set; }
    }
}
