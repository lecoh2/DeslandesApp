using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Obituario
    {
        public DateOnly DataObito { get; set; }
        public string LocalObito { get; set; } = string.Empty;
        public string Cartorio { get; set; } = string.Empty;
        public string Livro { get; set; } = string.Empty;
        public string Pagina { get; set; } = string.Empty;
        public string NumeroTermo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string DadosInventariante { get; set; } = string.Empty;
        public string ContatoInventariante { get; set; } = string.Empty;
        public string Herdeiros { get; set; } = string.Empty;
        #region Relacionamento Enumeradores
        public Testamento? Testamento { get; set; }
        #endregion
    }
}
