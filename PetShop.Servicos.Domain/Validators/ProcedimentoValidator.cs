using FluentValidation;
using PetShop.Servicos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PetShop.Servicos.Domain.Validators
{
    public class ProcedimentoValidator : AbstractValidator<Procedimento>
    {
        public ProcedimentoValidator()
        {
            RuleFor(x => x.Profissional)
                .NotNull();

            RuleFor(x => x.Situacao)
                .NotNull();

            RuleFor(x => x.Solicitante)
                .NotNull();

            RuleFor(x => x.TipoProcedimento)
                .NotNull();

            RuleFor(x => x.Valor)
                .GreaterThan(0);

            

        }
    }
}
