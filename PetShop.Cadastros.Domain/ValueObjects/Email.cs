using FluentValidation;
using PetShop.SharedKernel.Base.Domain;
using System.Collections.Generic;

namespace PetShop.Cadastros.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        Validators.EmailValidator validator = new Validators.EmailValidator();
        public string EnderecoCompleto { get; private set; }

        public Email(string endereco)
        {
            EnderecoCompleto = endereco;
            validator.ValidateAndThrow(this);
        }

        public string Dominio => EnderecoCompleto.Substring(EnderecoCompleto.IndexOf('@') + 1);
        public string Local => EnderecoCompleto.Substring(0, EnderecoCompleto.IndexOf('@'));
        
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Local;
            yield return Dominio;
        }
    }
}
