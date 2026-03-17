using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Processo : BaseEntity
    {
        public Guid? IdAcao { get; set; }
        public Guid? IdForo { get; set; }

        public string? Pasta { get; set; }
        public string? Titulo { get; set; }
        public string? NumeroProcesso { get; set; }
        public string? Juizo { get; set; }
        public string? Vara { get; set; }
        public string? LinkTribunal { get; set; }
        public string? Objeto { get; set; }

        public decimal? ValorCausa { get; set; }
        public DateOnly? Distribuido { get; set; }
        public decimal? ValorCondenacao { get; set; }

        public string? Observacao { get; set; }
        public string? Responsavael { get; set; }

        #region Relacionamentos

        public Foro? Foro { get; set; }
        public Acao? Acao { get; set; }

        // 🔥 RELAÇÃO N:N (correta)
        public ICollection<GrupoPessoaClientes> GrupoPessoaClientes { get; set; }

        public ICollection<Pessoa> OutrosEnvolvidos { get; set; }
        public ICollection<Qualificacao> Qualificacao { get; set; }

        #endregion

        #region Enumerações

        public Etiqueta? Etiqueta { get; set; }
        public Instancia? Instancia { get; set; }
        public Acesso? Acesso { get; set; }

        #endregion
    }
}

