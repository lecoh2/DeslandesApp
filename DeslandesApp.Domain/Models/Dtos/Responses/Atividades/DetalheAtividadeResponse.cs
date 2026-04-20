using DeslandesApp.Domain.Models.Dtos.Responses.Etiquetas;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Atividades
{
    public record DetalheAtividadeResponse
 (
     Guid Id,
     string Titulo,
     string Status,
     DateTime? DataInicio,
     DateTime? DataFim,
     string? Modalidade,
     string? Endereco,
     string? CriadoPor,
     List<UsuarioResumoResponse> Responsaveis,
     List<EtiquetaResponse> Etiquetas
 );
}
