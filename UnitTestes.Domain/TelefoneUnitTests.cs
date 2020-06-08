using FluentValidation;
using PetShop.Cadastros.Domain.Enumerations;
using PetShop.Cadastros.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTestes.Domain
{
    public class TelefoneUnitTests
    {
        [Fact(DisplayName = "DDD do Telefone não pode ser nulo")]
        public void Criar_Telefone_Nulo()
        {
            var ex = Assert.Throws<ValidationException>(() => new Telefone(null, null, null));
            var telefoneInvalido = ex.Message.IndexOf("DDD") > 0;
            Assert.True(telefoneInvalido);

        }

        [Fact(DisplayName = "DDD do Telefone não pode ser vazio")]
        public void Criar_DDD_Vazio()
        {
            var ex = Assert.Throws<ValidationException>(() => new Telefone("", null, null));
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
            var ex = Assert.Throws<ValidationException>(() => new Telefone("99", EnumTipoTelefone.Celular, "28355118"));
            var celinvalido = ex.Message.IndexOf("Numero") > 0;
            Assert.True(celinvalido);
        }


        [Fact(DisplayName = "Numero do telefone Celular Válido")]
        public void Criar_Numero_Celular_Valido()
        {
            var telefone = new Telefone("99", EnumTipoTelefone.Celular, "973180221");

            Assert.True(telefone.NumeroFormatado() == "(99) 973180221");
        }
    }
}
