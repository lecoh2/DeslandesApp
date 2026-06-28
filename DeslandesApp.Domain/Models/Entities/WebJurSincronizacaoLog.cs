using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class WebJurSincronizacaoLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime DataExecucao { get; set; }

        public int TotalRecebidos { get; set; }
        public int TotalImportados { get; set; }
        public int TotalFalhas { get; set; }

        public string Status { get; set; } // Sucesso | Erro parcial | Falha

        public string? MensagemErro { get; set; }
    }
}
