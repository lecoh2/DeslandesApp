using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
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
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d])[A-Za-z\d\S]{8,}$")
                 .WithMessage("A senha deve ter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas, números e símbolos. EX:(Procon2025@)");


          //  RuleFor(u => u.GrupoSetores)
          //.NotEmpty().WithMessage("É obrigatório escolher pelo menos um setor.");

          //  RuleFor(u => u.GrupoNiveis)
          //      .NotEmpty().WithMessage("É obrigatório escolher pelo menos um nível.");

            // validar cada IdSetor
            RuleForEach(u => u.GrupoSetores)
                .Must(gs => gs.IdSetor != Guid.Empty)
                .WithMessage("É obrigatório escolher pelo menos um setor.");

            // validar cada IdNivel
            RuleForEach(u => u.GrupoNiveis)
                .Must(gn => gn.IdNivel != Guid.Empty)
                .WithMessage("É obrigatório escolher pelo menos um nível.");
        }
    }
}
