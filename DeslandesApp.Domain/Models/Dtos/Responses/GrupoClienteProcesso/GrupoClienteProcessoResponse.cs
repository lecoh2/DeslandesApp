using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.GrupoClienteProcesso
{
    public class GrupoClienteProcessoResponse
    {
        public Guid IdPessoa { get; set; }
        public Guid IdProcesso { get; set; }
        public string? Nome { get; set; }
    }
}
