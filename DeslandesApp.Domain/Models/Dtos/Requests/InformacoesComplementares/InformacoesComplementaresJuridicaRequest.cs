using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares
{
    public record InformacoesComplementaresJuridicaRequest
   (
       string? Contato,
     string? Cargo,
     string? NomeBanco,
     string? Agencia,
     string? NumeroConta,
     string? Pix
    #region Relacionamento Enumeradores
   //TipoConta? TipoConta
   // Guid? IdPessoa = null // se quiser vincular opcionalmente
    #endregion
   );
}

