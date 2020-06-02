using FluentValidation;
using PetShop.Cadastros.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Cadastros.Domain.Validators
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(x => x.EnderecoCompleto)
                .EmailAddress();
        }
    }
}
