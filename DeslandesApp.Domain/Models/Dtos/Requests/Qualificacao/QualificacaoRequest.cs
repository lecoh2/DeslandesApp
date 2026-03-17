using DeslandesApp.Domain.Models.Dtos.Requests.Processo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Requests.Qualificacao
{
    public record QualificacaoRequest
    (
         string? NomeQualificacao, 

         Guid IdProcesso 
    );
}
