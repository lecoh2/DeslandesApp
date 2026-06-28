using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Validators
{
    using DeslandesApp.Domain.Models.Dtos.Requests.Contrato;
    using FluentValidation;

    public class ContratoRequestValidator : AbstractValidator<ContratoRequest>
    {
        public ContratoRequestValidator()
        {
            RuleFor(x => x.Numero)
                .NotEmpty()
                .WithMessage("O número do contrato é obrigatório.");

            RuleFor(x => x.PessoaId)
                .NotEmpty()
                .WithMessage("O cliente é obrigatório.");

           

            RuleFor(x => x.DataInicio)
                .NotEmpty()
                .WithMessage("A data de início é obrigatória.");

            RuleFor(x => x.ProcessosIds)
                .NotNull()
                .WithMessage("Selecione pelo menos um processo.");

            RuleFor(x => x.ProcessosIds)
                .Must(x => x != null && x.Any())
                .WithMessage("Selecione pelo menos um processo.");
        }
    }
}
