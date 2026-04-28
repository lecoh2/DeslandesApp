using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaCaso;
using DeslandesApp.Domain.Models.Enum;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Caso
{
    public class ObterCasoResponse
    {
        public Guid Id { get; set; }

        public string Pasta { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string? Observacao { get; set; }

        public AcessoCaso Acesso { get; set; }

        public DateTime? DataCadastro { get; set; }


        public Guid? ResponsavelId { get; set; }
        public string? ResponsavelNome { get; set; }

        public Guid? UsuarioCadastroId { get; set; }
        public string? UsuarioCadastroNome { get; set; }

        public List<GrupoCasoClienteResponse> GrupoCasoClientes { get; set; } = new();

        public List<GrupoCasoEnvolvidosResponse> GrupoCasoEnvolvidos { get; set; } = new();

        public List<GrupoEtiquetaCasoResponse> GrupoEtiquetaCaso { get; set; } = new();
    }

   
}