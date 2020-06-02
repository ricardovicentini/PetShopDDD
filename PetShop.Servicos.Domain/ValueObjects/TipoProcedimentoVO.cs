using FluentValidation;
using PetShop.Servicos.Domain.Enumerations;
using PetShop.Servicos.Domain.Validators;
using PetShop.SharedKernel.Base.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Servicos.Domain.ValueObjects
{
    public class TipoProcedimentoVO : ValueObject
    {
        private readonly TipoProcedimentoValidator validator = new TipoProcedimentoValidator();
        public string Descricao { get; private set; }
        public EnumCategoria Categoria { get; private set; }

        public TipoProcedimentoVO(string descricao, EnumCategoria categoria)
        {
            Descricao = descricao;
            Categoria = categoria;
            validator.ValidateAndThrow(this);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Descricao;
            yield return Categoria;
        }
    }
}
