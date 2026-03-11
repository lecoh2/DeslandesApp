using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares
{
    public record InformacoesComplementaresUpdateRequest
    (
     DateOnly DataNascimento,
     string NomeEmpresa,
     string Profissao,
     string AtividadeEconomica ,
     string EstadoCivil,
     string Codigo ,
     string NomePai ,
     string NomeMae ,
     string Naturalidade,
     string Nacionalidade ,
     string Comentario
    // Guid IdPessoa 
        );
}
