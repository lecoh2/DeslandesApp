using DeslandesApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Fotos : BaseEntity
    {
       // public Guid? IdFoto { get; set; }
        public Guid? IdUsuario { get; set; }
        public string? FotoNome { get; set; } = string.Empty;  // Nome do arquivo
        public string? FileUrl { get; set; } = string.Empty;   // Caminho acessível via Angular
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public Usuario? Usuario { get; set; } = null!;
    }
}
