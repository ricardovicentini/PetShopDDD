using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Cadastros.Application.Services.Adapters;
using PetShop.Cadastros.Application.Services.Ports;
using PetShop.Cadastros.Application.ViewModels;
using PetShop.Cadastros.Data.Context;
using PetShop.Cadastros.Data.Repository;
using System.Linq;
using Xunit;

namespace IntegrationTests
{
    public class FuncionarioIntegrationTests
    {
        private ServiceProvider serviceProvider;
        private IFuncionarioCadastroServices _funcionarioServices;
        private FuncionarioViewModel funcionarioVM = new FuncionarioViewModel()
        {
            Nome = "Ricardo",
            Sobrenome = "Vicentini",
            CPF = "123"
            
        };

        //startup
        public FuncionarioIntegrationTests()
        {
            serviceProvider = new ServiceCollection()
                .AddScoped<IFuncionarioCadastroServices,FuncionarioService>()
                .AddScoped<FuncionarioRepository, FuncionarioRepository>()
                .AddDbContext<CadastrosDBContext>(opt => opt.UseInMemoryDatabase("teste"))
                .AddAutoMapper(typeof(FuncionarioService))
                .BuildServiceProvider();

            _funcionarioServices = serviceProvider.GetService<IFuncionarioCadastroServices>();
        }

        [Fact(DisplayName = "Cliente deve ser persistido em uma base de dados")]
        public void Test1()
        {
            _funcionarioServices.Adicionar(funcionarioVM);
        }

        [Fact(DisplayName = "Apos cadastrar um funcionario deve haver funcionarios no BD")]
        public async void Cadastrar_Retornar_Funcionarios()
        {
            Test1();
            var func = await _funcionarioServices.ListarFincionarios();
            Assert.True(func.Count() > 0);
        }

        [Fact(DisplayName = "Ao Remover todos os funcionarios nenhum deverá estar no BD")]
        public async void Cadastrar_E_Remover_funcionarios()
        {
            Test1();
            var func = await _funcionarioServices.ListarFincionarios();
            foreach (var f in func.ToList())
            {
                _funcionarioServices.Remover(f.ID);
            }
            func = await _funcionarioServices.ListarFincionarios();
            Assert.True(func.Count() == 0);
        }


    }
}
