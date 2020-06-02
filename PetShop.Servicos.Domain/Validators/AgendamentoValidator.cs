using FluentValidation;
using PetShop.Servicos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Servicos.Domain.Validators
{
    public class AgendamentoValidator : AbstractValidator<Procedimento>
    {
        public AgendamentoValidator()
        {
            RuleFor(x => x.Data)
                .GreaterThan(DateTime.Now.AddHours(1))
                .WithMessage("A data de agendamento deve ser 1 hora acima da hora atual ou superior!");
        }
    }
}
