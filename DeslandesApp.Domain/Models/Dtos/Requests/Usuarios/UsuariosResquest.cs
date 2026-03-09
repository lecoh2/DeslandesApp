using DeslandesApp.Domain.Models.Dtos.Requests.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoSetores;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Usuarios
{
    public class UsuariosRequest
    {
        public string? NomeUsuario { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public DateTime? DataCadastro { get; set; }
        public Status? Status { get; set; }
        public string Email { get; set; }
      
        public List<GrupoSetorRequest>? GrupoSetor { get; set; }
      
        public List<GrupoNivelRequest>? GrupoNivel { get; set; }
    }

}
