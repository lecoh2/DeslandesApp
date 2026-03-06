using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Sexo : BaseEntity
    {

        //public Guid? IdSexo { get; set; }
        public string? NomeSexo { get; set; }
        #region Relacionamentos
        public List<Pessoa>? Pessoa { get; set; }
        #endregion
    }
}
