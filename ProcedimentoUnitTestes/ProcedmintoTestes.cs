using FluentValidation;
using PetShop.Cadastros.Domain.Entities;
using PetShop.Cadastros.Domain.Enumerations;
using PetShop.Cadastros.Domain.ValueObjects;
using PetShop.Servicos.Domain.Entities;
using PetShop.Servicos.Domain.Enumerations;
using PetShop.Servicos.Domain.ValueObjects;
using System;
using System.Runtime;
using Xunit;

namespace ProcedimentoUnitTestes
{
    public class ProcedmintoTestes
    {

        private static Procedimento CriarProcedimento()
        {
            return new Procedimento(
                            new Funcionario(
                                new NomePessoa("Maria", "da Silva"), "123"),
                                new TipoProcedimentoVO("Banho", EnumCategoria.Estetica),
                                new Cliente(
                                    new NomePessoa("Ricardo", "Vicentini"),
                                    cPF: "",
                                    new Telefone("11", EnumTipoTelefone.Residencial, "23023835"),
                                    new Email("a@b.com")
                                    ), 1m, null);
        }

        [Fact(DisplayName ="Procdimento deve ter o Profissional preenchido")]
        public void Criar_Procedimento_Sem_Profissional()
        {
            var ex = Assert.Throws<ValidationException>(() => new Procedimento(null, null, null, 0m, null));
            var profissionalInvalido = ex.Message.IndexOf("'Profissional'") > 0;
            Assert.True(profissionalInvalido);
        }
        [Fact(DisplayName = "Procedimento deve ter o tipo do procedimento informado")]
        public void Crriar_Prodeimento_Sem_tipo()
        {
            var ex = Assert.Throws<ValidationException>(() => new Procedimento(
                new Funcionario(
                    new NomePessoa("Maria","da Silva"),"123"), 
                    null,
                    null, 0m, null));
            var profissionalInvalido = ex.Message.IndexOf("'Profissional'") > 0;
            var procedimentoInvalido = ex.Message.IndexOf("'Tipo Procedimento'") > 0;
            Assert.True(!profissionalInvalido && procedimentoInvalido);
        }

        [Fact(DisplayName = "Procedimento deve ter o cliente informado")]
        public void Crriar_Prodeimento_Sem_Cliente()
        {
            var ex = Assert.Throws<ValidationException>(() => new Procedimento(
                new Funcionario(
                    new NomePessoa("Maria", "da Silva"), "123"),
                    new TipoProcedimentoVO("Banho",EnumCategoria.Estetica),
                    null, 0m, null));
            var profissionalInvalido = ex.Message.IndexOf("'Profissional'") > 0;
            var procedimentoInvalido = ex.Message.IndexOf("'Tipo Procedimento'") > 0;
            var solicitanteInvalido = ex.Message.IndexOf("'Solicitante'") > 0;
            Assert.True(!profissionalInvalido && !procedimentoInvalido && solicitanteInvalido);
        }

        [Fact(DisplayName = "Procedimento deve ter valor maior que zero")]
        public void Crriar_Prodeimento_Com_Valor_Zero()
        {
            var ex = Assert.Throws<ValidationException>(() => 
            new Procedimento(
                new Funcionario(
                    new NomePessoa("Maria", "da Silva"), "123"),
                    new TipoProcedimentoVO("Banho", EnumCategoria.Estetica),
                    new Cliente(
                        new NomePessoa("Ricardo","Vicentini"),
                        cPF:"",
                        new Telefone("11",EnumTipoTelefone.Residencial,"23023835"),
                        new Email("a@b.com")
                        ), 0m, null));
            var profissionalInvalido = ex.Message.IndexOf("'Profissional'") > 0;
            var procedimentoInvalido = ex.Message.IndexOf("'Tipo Procedimento'") > 0;
            var solicitanteInvalido = ex.Message.IndexOf("'Solicitante'") > 0;
            var valorInvalido = ex.Message.IndexOf("'Valor'") > 0;
            Assert
                .True(
                !profissionalInvalido && 
                !procedimentoInvalido && 
                !solicitanteInvalido &&
                valorInvalido
                );
        }

        [Fact(DisplayName = "Procedimento com todas as informacoes necessárias")]
        public void Criar_Prodeimento()
        {
            Procedimento procedimento = CriarProcedimento();

            Assert.True(procedimento != null);

        }


        [Fact(DisplayName = "Agendar um procedimento para uma data inválida")]
        public void Agendar_Procedimento_Para_Data_Nao_Passivel()
        {
            var procedimento = CriarProcedimento();
            var ex = Assert.Throws<ValidationException>(()=> procedimento.Agendar(DateTime.Now));
            var agendamentoInvalido = ex.Message.IndexOf("A data de agendamento deve ser 1 hora acima da hora atual ou superior!") >= 0;
            Assert.True(agendamentoInvalido);

        }

        [Fact(DisplayName = "Agendar um procedimento")]
        public void Agendar_Procedimento()
        {
            var procedimento = CriarProcedimento();
            var dataAgendamento = DateTime.Now.AddMinutes(61);
            procedimento.Agendar(data: dataAgendamento);


            Assert.True(procedimento.Data == dataAgendamento);

        }

        [Fact(DisplayName = "Cancelar  um procedimento")]
        public void Cancelar_Procedimento()
        {
            var procedimento = CriarProcedimento();
            
            procedimento.Cancelar();


            Assert.True(procedimento.Situacao ==  EnumSituacaoProcedimento.Cancelado);

        }
    }
}
