using FluentValidation;
using PetShop.Cadastros.Domain.Entities;
using PetShop.Cadastros.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTestes.Domain
{
    public class FuncionarioUnitTests
    {
        [Fact(DisplayName = "Nome do funcionario nao pode ser nulo")]
        public void CriarFuncionarioComNomeNulo()
        {
            var ex = Assert.Throws<ValidationException>(() => new Funcionario(null, null));
            var nomeInvalido = ex.Message.IndexOf("Nome") >= 0;
            Assert.True(nomeInvalido);
        }

        [Fact(DisplayName = "Cpf do funcionario nao pode ser nulo")]
        public void CriarFuncionarioComCpfNulo()
        {
            var ex = Assert.Throws<ValidationException>(() => new Funcionario(
                new NomePessoa("José","Da Silva"), null));
            var nomeInvalido = ex.Message.IndexOf("Nome") >= 0;
            var cpfInvalido = ex.Message.IndexOf("CPF") >= 0;
            Assert.True(!nomeInvalido && cpfInvalido);
        }

        [Fact(DisplayName = "Cpf do funcionario nao pode ser vazio")]
        public void CriarFuncionarioComCpfVazio()
        {
            var ex = Assert.Throws<ValidationException>(() => new Funcionario(
                new NomePessoa("José", "Da Silva"), ""));
            var nomeInvalido = ex.Message.IndexOf("Nome") >= 0;
            var cpfInvalido = ex.Message.IndexOf("CPF") >= 0;
            Assert.True(!nomeInvalido && cpfInvalido);
        }

        [Fact(DisplayName = "Criar funcionário valido")]
        public void CriarFuncionarioValido()
        {
            var funcionario = new Funcionario(
                new NomePessoa("José", "Da Silva"), "123");
            
            Assert.True(funcionario != null);
        }
    }
}

