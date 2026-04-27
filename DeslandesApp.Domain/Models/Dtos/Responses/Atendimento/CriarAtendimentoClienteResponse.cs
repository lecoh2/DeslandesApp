using DeslandesApp.Domain.Models.Dtos.Responses.GrupoAtendimentoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaAtendimento;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Atendimento
{
    public class CriarAtendimentoClienteResponse
    {
        public Guid Id { get; set; }
        public string Assunto { get; set; } = string.Empty;
        public string Registro { get; set; } = string.Empty;

        public List<GrupoAtendimentoClienteResponse> GrupoAtendimentoCliente { get; set; } = new();
        public List<GrupoEtiquetaAtendimentoResponse> GrupoAtendimentoEtiqueta { get; set; } = new();
    }
}
