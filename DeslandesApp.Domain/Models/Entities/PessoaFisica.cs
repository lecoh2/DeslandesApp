using DeslandesApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class PessoaFisica : Pessoa
    {
        public string RG { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string TituloEleitor { get; set; } = string.Empty;
        public string CarteiraTrabalho { get; set; } = string.Empty;
        public string PisPasep { get; set; } = string.Empty;
        public string CNH { get; set; } = string.Empty;
        public string Passaporte { get; set; } = string.Empty;
        public string CertidaoReservista { get; set; } = string.Empty;

        #region Relacionamento
        public ICollection<GrupoCasoCliente> GrupoCasoClientes { get; set; } = new List<GrupoCasoCliente>();

        public ICollection<GrupoCasoEnvolvido> GrupoCasoEnvolvidos { get; set; } = new List<GrupoCasoEnvolvido>();

        public ICollection<GrupoPessoasEtiquetas> GrupoPessoasEtiquetas { get; set; } = new List<GrupoPessoasEtiquetas>();

        public ICollection<GrupoEnvolvidosProcesso> GrupoEnvolvidosProcesso { get; set; } = new List<GrupoEnvolvidosProcesso>();

        #endregion
    }
}
