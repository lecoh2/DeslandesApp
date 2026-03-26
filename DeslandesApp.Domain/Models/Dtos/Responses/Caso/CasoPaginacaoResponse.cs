using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Caso
{
    public class CasoPaginacaoResponse
    {
        public Guid? Id { get; set; }
        public string Titulo { get; init; } 
        public DateTime DataCadastro { get; set; }
        public UsuarioResumoResponse? Responsavel { get; init; }

        public List<GrupoCasoClienteResponse> GrupoCasoClientes { get; init; } = new();
        public List<GrupoCasoEnvolvidosResponse> GrupoCasoEnvolvidos { get; init; } = new();
    }
}
