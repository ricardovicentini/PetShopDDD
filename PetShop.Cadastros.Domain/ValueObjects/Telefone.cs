using FluentValidation;
using Microsoft.VisualBasic;
using PetShop.Cadastros.Domain.Enumerations;
using PetShop.Cadastros.Domain.Validators;
using PetShop.SharedKernel.Base.Domain;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PetShop.Cadastros.Domain.ValueObjects
{
    public class Telefone : ValueObject
    {
        TelefoneValidator validator = new TelefoneValidator();
        public string DDD { get; private set; }
        public string Numero { get; private set; }
        public EnumTipoTelefone TipoTelefone { get; private set; }

        public Telefone(string dDD, EnumTipoTelefone tipoTelefone, string numero)
        {
            DDD = dDD;
            Numero = numero;
            TipoTelefone = tipoTelefone;
            validator.ValidateAndThrow(this);
        }

        public string NumeroCompleto()
        {
            return DDD + Numero;
        }
        public string NumeroFormatado()
        {
            return $"({DDD}) {Numero}";
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return DDD;
            yield return Numero;
            yield return TipoTelefone;
        }
    }
}
