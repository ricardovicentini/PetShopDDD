using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Cadastros.Application.Services.Adapters;
using PetShop.Cadastros.Application.Services.Ports;
using PetShop.Cadastros.Application.ViewModels;
using PetShop.Cadastros.Data.Context;
using PetShop.Cadastros.Data.Repository;
using PetShop.Procedimento.Data.Context;
using PetShop.Procedimento.Data.Repository;
using PetShop.Procedimento.EmailProviderMok;
using PetShop.Servicos.Application.Services.Adapters;
using PetShop.Servicos.Application.Services.Ports;
using PetShop.Servicos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProcedimentoIntegrationTests
{
    public class ProcediemIntegrationTests
    {
        private readonly ServiceProvider serviceProvider;
        private readonly IProcedimentoService _procedimentoServices;
        private readonly IClienteCadastroServices _clienteServices;
        private readonly IFuncionarioCadastroServices _funcionarioServices;


        private readonly ProcedimentoViewModel procedimentoVM = new ProcedimentoViewModel()
        {
            Descricao = "Banho",
            CategoriaID = 1,
            Data = DateTime.Now,
            SituacaoID = 1,
            Valor = 10m,
            Solicitacoes = new List<string>() { "Fazer tosa higienica", "não aparar as unhas" }
            
        };

        private readonly ClienteViewModel clienteVM = new ClienteViewModel()
        {
            Nome = "José",
            SobreNome = "da Silva",
            CPF = "123",
            DDD = "11",
            TipoTelefone = 3,
            NumeroTelefone = "974142141",
            Email = "a@b.com"
        };

        private FuncionarioViewModel funcionarioVM = new FuncionarioViewModel()
        {
            Nome = "Ricardo",
            Sobrenome = "Vicentini",
            CPF = "123"

        };


        public ProcediemIntegrationTests()
        {
            serviceProvider = new ServiceCollection()
                .AddScoped<IProcedimentoService, ProcedimentoServices>()
                .AddScoped<IClienteCadastroServices, ClienteCadastroService>()
                .AddScoped<IFuncionarioCadastroServices, FuncionarioService>()
                .AddScoped<ClienteRepository, ClienteRepository>()
                .AddScoped<FuncionarioRepository, FuncionarioRepository>()
                .AddScoped<ProcedimentoRepository, ProcedimentoRepository>()
                .AddDbContext<CadastrosDBContext>(opt => opt.UseInMemoryDatabase("test"))
                .AddDbContext<ProcedimentoDBContext>(opt => opt.UseInMemoryDatabase("test"))
                .AddAutoMapper(typeof(FuncionarioService), typeof(ProcedimentoServices))
                .AddMediatR(typeof(ProcedimentoServices))
                .AddScoped<IEmailProvider,SendEmail>()
                .BuildServiceProvider();

            _procedimentoServices = serviceProvider.GetService<IProcedimentoService>();
            _clienteServices = serviceProvider.GetService<IClienteCadastroServices>();
            _funcionarioServices = serviceProvider.GetService<IFuncionarioCadastroServices>();
        }

        [Fact(DisplayName ="Criar um procedimento no BD")]
        public async void Criar_Procedimento()
        {
            var cliente =  await _clienteServices.Adicionar(clienteVM);
            var funcionario = await _funcionarioServices.Adicionar(funcionarioVM);
            procedimentoVM.ProfissionalID = funcionario.ID;
            procedimentoVM.SolicitanteID = cliente.ID;
            await _procedimentoServices.Adicionar(procedimentoVM);
            var procedimentos = await _procedimentoServices.Todos();
            Assert.True(procedimentos.Any());
        }
        [Fact(DisplayName = "Agendar um procedimento")]
        public async void Agendar_Procedimento()
        {
            var cliente = await _clienteServices.Adicionar(clienteVM);
            var funcionario = await _funcionarioServices.Adicionar(funcionarioVM);
            procedimentoVM.ProfissionalID = funcionario.ID;
            procedimentoVM.SolicitanteID = cliente.ID;
            var procedimento = await _procedimentoServices.Adicionar(procedimentoVM);
            var dataAgendamento = DateTime.Now.AddDays(2);
            await _procedimentoServices.Agendar(procedimento.Id, dataAgendamento);
            var procedimentoAgendado = await _procedimentoServices.Procedimento(procedimento.Id);
            Assert.True(procedimentoAgendado.Data == dataAgendamento);

        }
    }
}
