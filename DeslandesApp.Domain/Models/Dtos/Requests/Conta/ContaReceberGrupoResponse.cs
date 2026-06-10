using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Conta
{
    public class ContaReceberGrupoResponse
    {
        public Guid ContratoId { get; set; }

        public string NomePessoa { get; set; }
        public string Descricao { get; set; }

        public decimal ValorTotal { get; set; }
        public int TotalParcelas { get; set; }

        public List<ContaReceberItemResponse> Parcelas { get; set; }
    }
}
