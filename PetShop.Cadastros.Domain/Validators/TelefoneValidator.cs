using FluentValidation;
using PetShop.Cadastros.Domain.Enumerations;
using PetShop.Cadastros.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PetShop.Cadastros.Domain.Validators
{
    public class TelefoneValidator : AbstractValidator<Telefone>
    {
        public TelefoneValidator()
        {
            RuleFor(x => x.DDD)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .Length(2)
                .Matches(@"^\d{2}$");

            RuleFor(x => x.Numero)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .Matches(@"^\d{8}$")
                .When(x => x.TipoTelefone == EnumTipoTelefone.Comercial || x.TipoTelefone == EnumTipoTelefone.Residencial)
                .WithMessage(x => $"Telefone {x.TipoTelefone.Name} deve conter 8 caracteres");




            RuleFor(x => x.Numero)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .Matches(@"^\d{9}$")
                .When(x => x.TipoTelefone == EnumTipoTelefone.Celular)
                .WithMessage(x => $"Telefone {x.TipoTelefone.Name} deve conter 9 caracteres");
                

            RuleFor(x => x.TipoTelefone)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull();
        }
    }
}
