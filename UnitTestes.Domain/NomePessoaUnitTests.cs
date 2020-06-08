using FluentValidation;
using PetShop.Cadastros.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTestes.Domain
{
    public class NomePessoaUnitTests
    {
        [Fact(DisplayName = "Nome da pessoa não pode ser nulo")]
        public void Criar_Nome_Pessoa_Nulo()
        {
            var ex = Assert.Throws<ValidationException>(() => new NomePessoa(null, null));
            var nomeInvalido = ex.Message.IndexOf("Nome") > 0;
            Assert.True(nomeInvalido);

        }

        [Fact(DisplayName = "Nome da pessoa não pode ser vazio")]
        public void Criar_Nome_Pessoa_Vazio()
        {
            var ex = Assert.Throws<ValidationException>(() => new NomePessoa("", null));
            var nomeInvalido = ex.Message.IndexOf("Nome") > 0;
            Assert.True(nomeInvalido);

        }

        [Fact(DisplayName = "Nome da pessoa deve ter no mínimo 2 caracteres")]
        public void Criar_Nome_Pessoa_com_Menos_DE_2_caracteres()
        {
            var ex = Assert.Throws<ValidationException>(() => new NomePessoa("R", null));
            var nomeInvalido = ex.Message.IndexOf("Nome") > 0;
            Assert.True(nomeInvalido);

        }

        [Fact(DisplayName = "Nome da pessoa deve ter no máximo 50 caracteres")]
        public void Criar_Nome_Pessoa_com_Mais_DE_50_caracteres()
        {
            var ex = Assert.Throws<ValidationException>(() => new NomePessoa("Eita nome grande do diaxo que preciso criar para da", null));
            var nomeInvalido = ex.Message.IndexOf("'Nome'") > 0;
            Assert.True(nomeInvalido);

        }

        [Fact(DisplayName = "Nome Valido")]
        public void Criar_Nome_Valido()
        {
            var ex = Assert.Throws<ValidationException>(() => new NomePessoa("Ricardo", null));
            var nomeInvalido = ex.Message.IndexOf("'Nome'") > 0;
            Assert.False(nomeInvalido);

        }



        [Fact(DisplayName = "Sobrenome da pessoa não pode ser nulo")]
        public void Criar_Sobrenome_Pessoa_Nulo()
        {
            var ex = Assert.Throws<ValidationException>(() => new NomePessoa("Ricardo", null));
            var nomeInvalido = ex.Message.IndexOf("'Sobrenome'") > 0;
            Assert.True(nomeInvalido);

        }

        [Fact(DisplayName = "Sobrenome da pessoa não pode ser vazio")]
        public void Criar_Sobrenome_Pessoa_Vazio()
        {
            var ex = Assert.Throws<ValidationException>(() => new NomePessoa("Ricardo", ""));
            var nomeInvalido = ex.Message.IndexOf("'Sobrenome'") > 0;
            Assert.True(nomeInvalido);

        }

        [Fact(DisplayName = "Sombrenome da pessoa deve ter no mínimo 2 caracteres")]
        public void Criar_Sobrenome_Pessoa_com_Menos_DE_2_caracteres()
        {
            var ex = Assert.Throws<ValidationException>(() => new NomePessoa("Ricardo", "a"));
            var nomeInvalido = ex.Message.IndexOf("'Sobrenome'") > 0;
            Assert.True(nomeInvalido);

        }

        [Fact(DisplayName = "Sobrenome da pessoa deve ter no máximo 50 caracteres")]
        public void Criar_Sobrenome_Pessoa_com_Mais_DE_50_caracteres()
        {
            var ex = Assert.Throws<ValidationException>(() => new NomePessoa("Ricardo", "Eita nome grande do diaxo que preciso criar para da"));
            var nomeInvalido = ex.Message.IndexOf("'Sobrenome'") > 0;
            Assert.True(nomeInvalido);

        }

        [Fact(DisplayName = "Sobrenome Valido")]
        public void Criar_Sobrenome_Valido()
        {

            var nomeInvalido = new NomePessoa("Ricardo", "Vicentini");
            Assert.True(nomeInvalido.NomeCompleto == "Ricardo Vicentini");

        }
    }
}
