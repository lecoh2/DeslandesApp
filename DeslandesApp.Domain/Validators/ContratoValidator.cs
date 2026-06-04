using DeslandesApp.Domain.Models.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Validators
{
    public class ContratoValidator : AbstractValidator<Contrato>
    {
        public ContratoValidator()
        {
            RuleFor(x => x.Numero)
    .NotEmpty()
    .Matches(@"^[\p{L}\p{N}\s\.\-\,\/ºª:]+$")
    .WithMessage("O campo deve conter apenas letras, números e caracteres válidos.");
        }
    }
}