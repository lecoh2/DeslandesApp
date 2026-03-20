using DeslandesApp.Domain.Models.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Validators
{
    public class CasoValidator : AbstractValidator<Caso>
    {
        public CasoValidator()
        {
            RuleFor(x => x.Titulo)
    .NotEmpty()
    .Matches(@"^[\p{L}\p{N}\s\.\-\,\/ºª:]+$")
    .WithMessage("O campo deve conter apenas letras, números e caracteres válidos.");
        }
    }
}