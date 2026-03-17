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
            RuleFor(x => x.Pasta)
     .Matches(@"^Processo:\s\d{7}-\d{2}\.\d{4}\.\d{1}\.\d{2}\.\d{4}\s\|\s[A-Za-zÀ-ÖØ-öø-ÿ\s]+(?:\s[Ee]\s[Oo][Uu][Tt][Rr][Oo][Ss])?\sx\s[A-Za-zÀ-ÖØ-öø-ÿ\s]+\s\|\s[Aa][Çç][Ãã][Oo]\s[Dd][Ee]\s[A-Za-zÀ-ÖØ-öø-ÿ\s]+$")
     .WithMessage("Formato inválido. Use: Processo: 0000000-00.0000.0.00.0000 | Nome x Nome | Ação de Tipo");

            RuleFor(x => x.NumeroProcesso)
     .Matches(@"^\d{7}-\d{2}\.\d{4}\.\d{1}\.\d{2}\.\d{4}$")
     .WithMessage("Número de processo inválido. Use o padrão CNJ: 0000000-00.0000.0.00.0000");
            RuleFor(x => x.Titulo)
    .Matches(@"^[A-Za-z0-9]+$")
    .WithMessage("O campo deve conter apenas letras e números.");
            RuleFor(x => x.LinkTribunal)
    .Matches(@"^(https?:\/\/)(www\.)?[A-Za-z0-9\-._~:/?#[\]@!$&'()*+,;=%]+$")
    .WithMessage("Informe um link válido (http ou https).");
            RuleFor(x => x.Juizo)
    .Matches(@"^\d+$")
    .WithMessage("O campo deve conter apenas números.");
        }
    }
}
