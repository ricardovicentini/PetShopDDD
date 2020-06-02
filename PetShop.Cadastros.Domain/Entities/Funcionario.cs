using FluentValidation;
using PetShop.Cadastros.Domain.Validators;
using PetShop.Cadastros.Domain.ValueObjects;
using PetShop.SharedKernel.Base.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Cadastros.Domain.Entities
{
    public class Funcionario : Entity
    {
        private readonly FuncionarioValidator validator = new FuncionarioValidator();
        public NomePessoa Nome { get; private set; }
        public string CPF { get; private set; }

        public Funcionario(NomePessoa nome, string cPF)
        {
            Nome = nome;
            CPF = cPF;
            validator.ValidateAndThrow(this);
        }
    }
}
