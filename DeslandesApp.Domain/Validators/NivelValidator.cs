using DeslandesApp.Domain.Models.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Validators
{
    public class NivelValidator : AbstractValidator<Niveis>
    {


        public NivelValidator()
        {
            RuleFor(n => n.NomeNivel).NotEmpty().WithMessage("O Nome do Nível é obrigatório.").
                Length(6, 50).WithMessage("O Nome do Nível deve conter entre 6 e 50 caracteres.");
        }
    }
}
