using FluentValidation;
using PetShop.Cadastros.Domain.Entities;
using PetShop.Cadastros.Domain.Enumerations;
using PetShop.Cadastros.Domain.Validators;
using PetShop.Cadastros.Domain.ValueObjects;
using System;
using Xunit;


namespace UnitTestes.Domain
{
    public class CadastrosUnitTest
    {
        [Fact(DisplayName ="Somente aceitar emails válidos")]
        public void Criar_Um_Email_Invalido()
        {
            var ex = Assert.Throws<ValidationException>(() => new Email("abcd@abc"));
            var emailInvalido = ex.Message.IndexOf("email inválido") > 0;
            Assert.True(emailInvalido);

        }

        [Fact(DisplayName = "LocalPart deve exibir a primeira parte do email fornecido")]
        public void Testar_Propriedade_LocalPart()
        {
            var email = new Email("ricardo@uol.com.br");
            var local = email.Local;
            Assert.Equal("ricardo", local);

        }

        [Fact(DisplayName ="Domínio deve possuir a segunda parte do email depois do @")]
        public void Testar_Propriedade_Dominio()
        {
            var email = new Email("ricardo@uol.com.br");
            var local = email.Dominio;
            Assert.Equal("uol.com.br", local);
        }

       

        

        [Fact(DisplayName = "Cliente não pode ter o nome nulo")]
        public void Criar_Cliente_Com_nome_Nulol()
        {

            var ex = Assert.Throws<ValidationException>(() => new Cliente(null, null, null, null));
            var clienteNomeInvalido = ex.Message.IndexOf("'Nome'") > 0;
            Assert.True(clienteNomeInvalido);

        }

        [Fact(DisplayName = "Cliente com nome preenchido")]
        public void Criar_Cliente_Com_nome_Preenchido()
        {

            var ex = Assert.Throws<ValidationException>(() => new Cliente(new NomePessoa("Ricardo","Vicentini"), null, null, null));
            var clienteNomeInvalido = ex.Message.IndexOf("'Nome'") > 0;
            Assert.False(clienteNomeInvalido);

        }

        [Fact(DisplayName = "Telefone do cliente não pode ser nulo")]
        public void Criar_Cliente_Com_Telefone_Nulo()
        {

            var ex = Assert.Throws<ValidationException>(() => new Cliente(new NomePessoa("Ricardo", "Vicentini"), null, null, null));
            var clienteNomeInvalido = ex.Message.IndexOf("'Telefone'") > 0;
            Assert.True(clienteNomeInvalido);

        }

        [Fact(DisplayName = "cliente com telefone informado")]
        public void Criar_Cliente_Com_Telefone()
        {

            var ex = Assert.Throws<ValidationException>(() => 
                new Cliente(new NomePessoa("Ricardo", "Vicentini"),"",
                new Telefone("11", EnumTipoTelefone.Celular, "973180221"),null));
            var clienteNomeInvalido = ex.Message.IndexOf("'Telefone'") > 0;
            Assert.False(clienteNomeInvalido);

        }

        [Fact(DisplayName = "cliente não pode ter email nulo")]
        public void Criar_Cliente_Com_Email_Nulo()
        {

            var ex = Assert.Throws<ValidationException>(() =>
                new Cliente(new NomePessoa("Ricardo", "Vicentini"), "",
                new Telefone("11", EnumTipoTelefone.Celular, "973180221"), null));
            var clienteNomeInvalido = ex.Message.IndexOf("'Email'") > 0;
            Assert.True(clienteNomeInvalido);

        }

        [Fact(DisplayName = "cliente com email informado")]
        public void Criar_Cliente_Com_Email()
        {

            var cliente = 
                new Cliente(new NomePessoa("Ricardo", "Vicentini"), "",
                new Telefone("11", EnumTipoTelefone.Celular, "973180221"), 
                new Email("a@b.com"));
            
            Assert.True(cliente != null);

        }


    }
}
