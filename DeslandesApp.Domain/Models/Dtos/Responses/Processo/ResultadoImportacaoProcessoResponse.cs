using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Processo
{
    public class ResultadoImportacaoProcessoResponse
    {
        public int Sucesso { get; set; }

        public int Falhas { get; set; }

        public List<string> Erros { get; set; }
    }
}
