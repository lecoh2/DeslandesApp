using DeslandesApp.Domain.Models.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Validators
{
    public class ProcessoValidator : AbstractValidator<Processo>
    {
        public ProcessoValidator()
        {
           
            RuleFor(x => x.NumeroProcesso)
     .Matches(@"^\d{7}-\d{2}\.\d{4}\.\d{1}\.\d{2}\.\d{4}$")
     .WithMessage("Número de processo inválido. Use o padrão CNJ: 0000000-00.0000.0.00.0000");
            RuleFor(x => x.Titulo)
     .NotEmpty()
     .Matches(@"^[\p{L}\p{N}\s]+$")
     .WithMessage("O campo deve conter apenas letras e números.");
            RuleFor(x => x.LinkTribunal)
    .Matches(@"^(https?:\/\/)(www\.)?[A-Za-z0-9\-._~:/?#[\]@!$&'()*+,;=%]+$")
    .WithMessage("Informe um link válido (http ou https).");
            
        }
    }
}
