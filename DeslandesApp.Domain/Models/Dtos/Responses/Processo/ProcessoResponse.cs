using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Responses.Processo
{
    public record ProcessoResponse
   (
       Guid? AcaoId,
       Guid VaraId,
       Guid? UsuarioResponsavelId,

       string? Pasta,
       string? Titulo,
       string? NumeroProcesso,
       string? LinkTribunal,
       string? Objeto,
       decimal? ValorCausa,
       DateOnly? Distribuido,
       decimal? ValorCondenacao,
       string? Observacao,
       int? Instancia,
       int? Acesso
   );
}
