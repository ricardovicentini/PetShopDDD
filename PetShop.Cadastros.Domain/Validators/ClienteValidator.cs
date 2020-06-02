using FluentValidation;
using PetShop.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PetShop.Cadastros.Domain.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull();

            RuleFor(x => x.CPF)
                .NotNull();

            RuleFor(x => x.Email)
                .NotNull();

            RuleFor(x => x.Telefone)
                .NotNull();
        }
    }
}
