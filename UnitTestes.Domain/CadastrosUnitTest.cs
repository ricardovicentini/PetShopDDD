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

        [Fact(DisplayName = "DDD do Telefone não pode ser nulo")]
        public void Criar_Telefone_Nulo()
        {
            var ex = Assert.Throws<ValidationException>(()=> new Telefone(null, null, null));
            var telefoneInvalido = ex.Message.IndexOf("DDD") > 0;
            Assert.True(telefoneInvalido);

        }

        [Fact(DisplayName = "DDD do Telefone não pode ser vazio")]
        public void Criar_DDD_Vazio()
        {
            var ex = Assert.Throws<ValidationException>(()=> new Telefone("", null, null));
            var telefoneInvalido = ex.Message.IndexOf("DDD") > 0;
            Assert.True(telefoneInvalido);

        }

        [Fact(DisplayName = "DDD do Telefone não pode ter menos de 2 digitos")]
        public void Criar_DDD_Com_Menos_Que_Dois_Digitos()
        {
            var ex = Assert.Throws<ValidationException>(() => new Telefone("1", null, null));
            var telefoneInvalido = ex.Message.IndexOf("DDD") > 0;
            Assert.True(telefoneInvalido);

        }

        [Fact(DisplayName = "DDD do Telefone não pode ter mais de 2 digitos")]
        public void Criar_DDD_Com_Mais_Que_Dois_Digitos()
        {
            var ex = Assert.Throws<ValidationException>(() => new Telefone("123", null, null));
            var telefoneInvalido = ex.Message.IndexOf("DDD") > 0;
            Assert.True(telefoneInvalido);

        }

        [Fact(DisplayName = "DDD do Telefone deve ser numerico")]
        public void Criar_DDD_Com_Letras()
        {
            var ex = Assert.Throws<ValidationException>(() => new Telefone("XX", null, null));
            var telefoneInvalido = ex.Message.IndexOf("DDD") > 0;
            Assert.True(telefoneInvalido);

        }

        [Fact(DisplayName = "DDD Correto")]
        public void Criar_DDD_Correto()
        {
            var ex = Assert.Throws<ValidationException>(() => new Telefone("99", null, null));
            var telefoneInvalido = ex.Message.IndexOf("DDD") > 0;
            Assert.False(telefoneInvalido);

        }

        [Fact(DisplayName = "Tipo do telefone não pode ser nulto")]
        public void Criar_Tipo_Telefone_Nulto()
        {
            var ex = Assert.Throws<ValidationException>(() => new Telefone("99", null, null));
            var telefoneInvalido = ex.Message.IndexOf("Tipo") > 0;
            Assert.True(telefoneInvalido);

        }

        [Fact(DisplayName = "Tipo do telefone deve ser informado")]
        public void Criar_Com_Tipo_Telefone()
        {
            var ex = Assert.Throws<ValidationException>(() => new Telefone("99", EnumTipoTelefone.Residencial, null));
            var telefoneInvalido = ex.Message.IndexOf("Tipo") > 0;
            Assert.False(telefoneInvalido);
        }

        [Fact(DisplayName = "Numero do telefone não pode ser vazio")]
        public void Criar_Com_Numero_Vazio()
        {
            var ex = Assert.Throws<ValidationException>(() => new Telefone("99", EnumTipoTelefone.Residencial, ""));
            var telefoneInvalido = ex.Message.IndexOf("Numero") > 0;
            Assert.True(telefoneInvalido);
        }

        [Fact(DisplayName = "Numero do telefone deve conter 8 digitos se Residencial")]
        public void Criar_Numero_Com_Menos_De_8_Digitos()
        {
            var ex = Assert.Throws<ValidationException>(() => new Telefone("99", EnumTipoTelefone.Residencial, "2835541"));
            var telefoneInvalido = ex.Message.IndexOf("Numero") > 0;
            Assert.True(telefoneInvalido);
        }

        [Fact(DisplayName = "Numero do telefone deve conter 8 digitos se Residencial")]
        public void Criar_Numero_Com_Mais_De_8_Digitos()
        {
            var ex = Assert.Throws<ValidationException>(() => new Telefone("99", EnumTipoTelefone.Residencial, "283554112"));
            var telefoneInvalido = ex.Message.IndexOf("Numero") > 0;
            Assert.True(telefoneInvalido);
        }

        [Fact(DisplayName = "Numero do telefone deve ser numerico")]
        public void Criar_Numero_Com_Caracteres_Alfanumericos()
        {
            var ex = Assert.Throws<ValidationException>(() => new Telefone("99", EnumTipoTelefone.Residencial, "283ss118"));
            var telefoneInvalido = ex.Message.IndexOf("Numero") > 0;
            Assert.True(telefoneInvalido);
        }

        [Fact(DisplayName = "Numero do telefone Comercial Válido")]
        public void Criar_Numero_Valido()
        {
            var telefone = new Telefone("99", EnumTipoTelefone.Comercial, "28355118");
            
            Assert.True(telefone.NumeroCompleto() == "9928355118");
        }

        [Fact(DisplayName = "Numero do telefone celular inválido")]
        public void Criar_Numero_Celular_Invalido()
        {
            var ex = Assert.Throws<ValidationException>(()=> new Telefone("99", EnumTipoTelefone.Celular, "28355118"));
            var celinvalido = ex.Message.IndexOf("Numero") > 0;
            Assert.True(celinvalido);
        }


        [Fact(DisplayName = "Numero do telefone Celular Válido")]
        public void Criar_Numero_Celular_Valido()
        {
            var telefone = new Telefone("99", EnumTipoTelefone.Celular, "973180221");

            Assert.True(telefone.NumeroFormatado() == "(99) 973180221");
        }

        [Fact(DisplayName = "Nome da pessoa não pode ser nulo")]
        public void Criar_Nome_Pessoa_Nulo()
        {
            var ex = Assert.Throws<ValidationException>(() => new NomePessoa(null, null));
            var nomeInvalido = ex.Message.IndexOf("Nome")>0;
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
