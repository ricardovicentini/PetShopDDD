using FluentValidation;
using PetShop.Cadastros.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Cadastros.Domain.Validators
{
    public class NomePessoaValidator : AbstractValidator<NomePessoa>
    {
        public NomePessoaValidator()
        {
            RuleFor(x => x.Nome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(x=> x.Sobrenome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
        }
    }
}
