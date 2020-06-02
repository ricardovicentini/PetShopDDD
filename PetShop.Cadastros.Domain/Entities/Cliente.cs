using FluentValidation;
using PetShop.Cadastros.Domain.Validators;
using PetShop.Cadastros.Domain.ValueObjects;
using PetShop.SharedKernel.Base.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Cadastros.Domain.Entities
{
    public class Cliente : Entity
    {
        ClienteValidator validator = new ClienteValidator();
        public NomePessoa Nome { get; private set; }
        public string CPF { get; private set; }
        public Telefone Telefone { get; private set; }
        public Email Email { get; private set; }

        public Cliente(NomePessoa nome, string cPF, Telefone telefone, Email email)
        {
            Nome = nome;
            CPF = cPF;
            Telefone = telefone;
            Email = email;
            validator.ValidateAndThrow(this);
        }
    }
}
