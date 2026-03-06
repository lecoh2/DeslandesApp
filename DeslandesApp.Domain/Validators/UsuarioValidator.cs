using DeslandesApp.Domain.Models.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.NomeUsuario).NotEmpty().WithMessage("O Nome do Usuário é obrigatório.").
                Length(6, 50).WithMessage("O Nome do Usuário deve conter entre 6 e 50 caracteres.");
            RuleFor(u => u.Login).NotEmpty().WithMessage("O Login é obrigatório").
                Length(3, 50).WithMessage("O Login dever contaer entre 3 e 50 caracteres");
            RuleFor(u => u.Senha)
              .NotEmpty().WithMessage("A senha é obrigatória")
              .Length(4, 50).WithMessage("A senha deve conter entre 4 e 50 caracteres")
              .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).+$")
              .WithMessage("A senha deve conter letra maiúscula, minúscula, número e caractere especial");
            RuleFor(u => u.GrupoSetores).NotEmpty().WithMessage("É obrigatório a escolha de pelos menos um setor.");
            RuleFor(u => u.GrupoNiveis).NotEmpty().WithMessage("É Obrigatório a escolha de pelos menos um nivel");
        }
    }
}
