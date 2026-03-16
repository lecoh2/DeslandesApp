using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Processo
    {
        public Guid? IdAcao { get; set; }
        public Guid? IdForo { get; set; }
        public string? Pasta { get; set; } = string.Empty;
        public string? Titulo { get; set; } = string.Empty;
        public string? NumeroProcesso { get; set; } = string.Empty;  
        public string? Juizo { get; set; } = string.Empty;   
        public string? Vara { get; set; } = string.Empty;
        public string? LinkTribunal  { get; set; } = string.Empty;
        public string? Objeto { get; set; } = string.Empty;
        public decimal? ValorCausa { get; set; } 
        public DateOnly? Distribuido { get; set; }
        public decimal? ValorCondenacao { get; set; }
        public string? Observacao { get; set; } = string.Empty;
        public string? Responsavael  { get; set; } = string.Empty;
       

        #region Relacionamentos
        public Foro? Foro { get; set; }
        public Acao? Acao { get;set; }
        public ICollection<Pessoa> Pessoas { get; set; }
        public ICollection<Pessoa> OutrosEnvolvidos { get; set; }    
        public ICollection<Qualificacao> Qualificacao { get; set; }


        #endregion
        #region Enumerações
        public Etiqueta ? Etiqueta { get; set; }
        public Instancia? Instancia { get; set; }
        public Acesso? Acesso { get; set; }
        #endregion
    }
}
