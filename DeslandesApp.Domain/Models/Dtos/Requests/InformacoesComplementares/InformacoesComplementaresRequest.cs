using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares
{
    public record InformacoesComplementaresRequest
   (
       string? DataNascimento = null,  // agora opcional
       string? NomeEmpresa = null,
       string? Profissao = null,
       string? AtividadeEconomica = null,
       string? EstadoCivil = null,
       string? Codigo = null,
       string? NomePai = null,
       string? NomeMae = null,
       string? Naturalidade = null,
       string? Nacionalidade = null,
       string? Comentario = null
   // Guid? IdPessoa = null // se quiser vincular opcionalmente
   );
}
