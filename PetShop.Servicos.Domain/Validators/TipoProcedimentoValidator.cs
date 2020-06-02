using FluentValidation;
using PetShop.Servicos.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Servicos.Domain.Validators
{
    public class TipoProcedimentoValidator : AbstractValidator<TipoProcedimentoVO>
    {
        public TipoProcedimentoValidator()
        {
            RuleFor(x => x.Descricao)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .MinimumLength(3)
                .MaximumLength(255);

            RuleFor(x => x.Categoria)
                .NotNull();
        }
    }
}
