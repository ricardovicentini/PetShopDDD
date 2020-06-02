using FluentValidation;
using PetShop.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Cadastros.Domain.Validators
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull();

            RuleFor(x => x.CPF)
                .NotNull()
                .NotEmpty();
        }
    }
}
