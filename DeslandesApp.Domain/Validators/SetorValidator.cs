using DeslandesApp.Domain.Models.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Validators
{
    public class SetorValidator : AbstractValidator<Setor>
    {


        public SetorValidator()
        {
            RuleFor(n => n.NomeSetor).NotEmpty().WithMessage("O Nome do Setor é obrigatório.").
                Length(6, 50).WithMessage("O Nome do Setor deve conter entre 4 e 50 caracteres.");
        }
    }
}
