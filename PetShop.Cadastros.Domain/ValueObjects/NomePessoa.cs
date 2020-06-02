using FluentValidation;
using PetShop.Cadastros.Domain.Validators;
using PetShop.SharedKernel.Base.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace PetShop.Cadastros.Domain.ValueObjects
{
    public class NomePessoa : ValueObject
    {
        NomePessoaValidator validator = new NomePessoaValidator();
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        public NomePessoa(string nome, string sobreNome)
        {
            Nome = nome;
            Sobrenome = sobreNome;
            validator.ValidateAndThrow(this);
        }

        public string NomeCompleto => Nome.Trim() + " " + Sobrenome.Trim();
        

        public IEnumerable<char> Iniciais()
        {
            var nomes = NomeCompleto.Split(' ').ToList();
            for (int i = 0; i < nomes.Count(); i++)
            {
                yield return nomes[i].ToUpper().ToArray()[0];
            }
        }

        

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Nome;
            yield return Sobrenome;
        }
    }
}
